using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using OfficeOpenXml;

namespace CASTEP_Management
{
    public class CASTEPextract
    {
        Regex pressureReg = new Regex(@".*Pressure: *([-+]?\d*\.\d+|\d+) *");
        Regex bulkModulusReg = new Regex(@" *BFGS: Final bulk modulus *= *([-+]?\d*\.\d+|\d+) *GPa");
        Regex enthalpyReg = new Regex(@" *BFGS: Final Enthalpy *= *([-+]?\d*\.\d+E?[+-]?\d*|\d+) *eV");
        Regex cellVolumnReg = new Regex(@" *Current cell volume *= *([-+]?\d*\.\d+|\d+) *A\*\*3");
        Regex aReg = new Regex(@" +a = *([-+]?\d*\.\d+|\d+) *");
        Regex angleReg = new Regex(@" +alpha = *([-+]?\d*\.\d+|\d+) *");
        Regex energyReg = new Regex(@" *NB est\. .+K energy *\(.*\) *= *([-+]?\d*\.\d+|\d+) *eV *");
        List<Regex> contentReg = new List<Regex>();

        Regex startFocusedContentReg = new Regex(@"BFGS: Final Configuration:");

        Regex substanceReg = new Regex(@" *Pseudo atomic calculation performed for ([^ ]*) *");
        Regex taskReg = new Regex(@" *type of calculation *: (.*) *");
        Regex atomNumReg = new Regex(@" *Total number of ions in cell *= *([-+]?\d*\.\d+|\d+) *");
        Regex quality1Reg = new Regex(@" *plane wave basis set cut-off *: *([-+]?\d*\.\d+|\d+) *eV *");
        Regex quality0Reg = new Regex(@" *MP grid size for SCF calculation is  ([ \d]*)");
        Regex functionalReg = new Regex(@" *using functional *: *(.*) *");

        List<string> pathList = new List<string>();
        List<string> filenameList = new List<string>();
        List<double> stressList = new List<double>();
        ProgressBar bar;

        public CASTEPextract(ProgressBar bar)
        {
            this.bar = bar;
            this.bar.Minimum = 0;
            this.bar.Maximum = 0;
        }

        public void AddFilename(String path, double stress, String filename)
        {
            this.pathList.Add(path);
            this.stressList.Add(stress);
            this.filenameList.Add(filename);
            this.bar.Maximum += 1;
        }


        public List<string> GetStringFromFile(String path)
        {
            List<string> output = new List<string>();
            List<string> lines = new List<string>();
            using (StreamReader r = new StreamReader(path))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }

        public CASTEPsubObj SetObjProperty(string focusContent, ref CASTEPsubObj obj)
        {
            //CASTEPsubObj obj = new CASTEPsubObj();
            Match pressureMatch = pressureReg.Match(focusContent);
            if (pressureMatch.Success)
                obj.pressure = double.Parse(pressureMatch.Groups[1].Value);
            else
                obj.pressure = 0;

            Match bulkModulusMatch = bulkModulusReg.Match(focusContent);
            if (bulkModulusMatch.Success)
                obj.bulkModulus = double.Parse(bulkModulusMatch.Groups[1].Value);
            else
                obj.bulkModulus = 0;

            Match cellVolumnMatch = cellVolumnReg.Match(focusContent);
            if (cellVolumnMatch.Success)
                obj.cellVolumn = double.Parse(cellVolumnMatch.Groups[1].Value);
            else
                obj.cellVolumn = 0;

            Match aMatch = aReg.Match(focusContent);
            if (aMatch.Success)
                obj.a = double.Parse(aMatch.Groups[1].Value);
            else
                obj.a = 0;

            Match angleMatch = angleReg.Match(focusContent);
            if (angleMatch.Success)
                obj.angle = double.Parse(angleMatch.Groups[1].Value);
            else
                obj.pressure = 0;

            Match enthalpyMatch = enthalpyReg.Match(focusContent);
            if (enthalpyMatch.Success)
                obj.enthalpy = double.Parse(enthalpyMatch.Groups[1].Value);
            else
                obj.enthalpy = 0;

            //Match energyMatch = energyReg.Match(focusContent);
            //if (energyMatch.Success)
            //    obj.energy = double.Parse(energyMatch.Groups[1].Value);
            //else
            //    obj.energy = 0;


            return obj;
        }

        public CASTEPinfo Extract()
        {
            CASTEPinfo output = new CASTEPinfo();
            int i = 0;
            this.bar.Value = 0;
            foreach (String path in this.pathList)
            {
                this.bar.Value += 1;
                List<string> lines = GetStringFromFile(path);

                string focusContent = "";
                bool isStartFocus = false;
                CASTEPsubObj obj = new CASTEPsubObj(); 
                foreach (string line in lines)
                {
                    if (startFocusedContentReg.Match(line).Success)
                        isStartFocus = true;
                    if (isStartFocus)
                        focusContent += line;

                    if (output.content == -1.0)
                    {
                        Match atomNumMatch = atomNumReg.Match(line);
                        if (atomNumMatch.Success)
                            output.content = float.Parse(atomNumMatch.Groups[1].Value);
                    }

                    if (output.substance == "")
                    {
                        Match substanceMatch = substanceReg.Match(line);
                        if (substanceMatch.Success)
                            output.substance = substanceMatch.Groups[1].Value;
                    }

                    if (output.task == "")
                    {
                        Match taskMatch = taskReg.Match(line);
                        if (taskMatch.Success)
                            output.task = taskMatch.Groups[1].Value;
                    }

                    if (output.quality0 == "")
                    {
                        Match quality0Match = quality0Reg.Match(line);
                        if (quality0Match.Success)
                            output.quality0 = quality0Match.Groups[1].Value;
                    }

                    if (output.quality1 == "")
                    {
                        Match quality1Match = quality1Reg.Match(line);
                        if (quality1Match.Success)
                            output.quality1 = quality1Match.Groups[1].Value;
                    }

                    //if (output.space == "")
                    //{
                    //    Match spaceMatch = spaceReg.Match(line);
                    //    if (spaceMatch.Success)
                    //        output.space = spaceMatch.Groups[1].Value;
                    //}

                    if (output.functional == "")
                    {
                        Match functionalMatch = functionalReg.Match(line);
                        if (functionalMatch.Success)
                            output.functional = functionalMatch.Groups[1].Value;
                    }

                    Match energyMatch = energyReg.Match(line);
                    if (energyMatch.Success)
                        obj.energy = double.Parse(energyMatch.Groups[1].Value);
                }

                SetObjProperty(focusContent,ref obj);
                //obj.energy = obj.enthalpy - obj.cellVolumn * obj.pressure;
                obj.V = obj.cellVolumn / output.content;
                obj.E = obj.energy / output.content;
                obj.stress = stressList[i];
                output.record.Add(obj);
                i++;
            }
            return output;
        }


    }

}
