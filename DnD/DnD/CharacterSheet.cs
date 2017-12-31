using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DnD
{

    public partial class CharacterStatsForm : Form
    {
        public CharacterStatsForm()
        {
            InitializeComponent();
            getHalfLevel();
        }
        /********************** Level Text Box Controlls ********************/
        private void levelUpButton_Click(object sender, EventArgs e)
        {
            int level = int.Parse(levelTextBox.Text);
            level = level + 1;
            levelTextBox.Text = level.ToString();
        }
        private void levelDownButton_Click(object sender, EventArgs e)
        {
            int level = int.Parse(levelTextBox.Text);
            level = level - 1;
            levelTextBox.Text = level.ToString();
        }
        private void levelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (levelTextBox.Text == "1") { levelDownButton.Enabled = false; }
            else { levelDownButton.Enabled = true; }
            if // Makes sure there is a value in the box before atempting math on it.
                (strAbilityModTextBox.Text == "" || conModTotalTextBox.Text == "" ||
                 dexModTotalTextBox.Text == "" || intModTotalTextBox.Text == "" || 
                  wisModTotalTextBox.Text == "" || chaModTotalTextBox.Text == "")
                return; 
            else
                strModTotalTextBox.Text = (getMod(int.Parse(strAbilityScoreTextBox.Text)) + getHalfLevel()).ToString();
                conModTotalTextBox.Text = (getMod(int.Parse(conAbilityScoreTextBox.Text)) + getHalfLevel()).ToString();
                dexModTotalTextBox.Text = (getMod(int.Parse(dexAbilityScoreTextBox.Text)) + getHalfLevel()).ToString();
                intModTotalTextBox.Text = (getMod(int.Parse(intAbilityScoreTextBox.Text)) + getHalfLevel()).ToString();
                wisModTotalTextBox.Text = (getMod(int.Parse(wisAbilityScoreTextBox.Text)) + getHalfLevel()).ToString();
                chaModTotalTextBox.Text = (getMod(int.Parse(chaAbilityScoreTextBox.Text)) + getHalfLevel()).ToString();
        }
        /********************** End Level Text Box Controlls ****************/

        /**************Get ability mod values via text change ***************/
        // ----------------Str Mod---------------
        private void strAbilityScoreTextBox_TextChanged(object sender, EventArgs e)
        {           
            if (string.IsNullOrEmpty(strAbilityScoreTextBox.Text))
                strAbilityScoreTextBox.Text = "0";
            else
                strAbilityModTextBox.Text = getMod(int.Parse(strAbilityScoreTextBox.Text)).ToString();
                strModTotalTextBox.Text = getModTotal(int.Parse(strAbilityScoreTextBox.Text),int.Parse(levelTextBox.Text)).ToString();
        }
        // ----------------Con Mod--------------
        private void conAbilityScoreTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conAbilityScoreTextBox.Text))
                conAbilityScoreTextBox.Text = "0";
            else
                conAbilityModTextBox.Text = getMod(int.Parse(conAbilityScoreTextBox.Text)).ToString();
                conModTotalTextBox.Text = getModTotal(int.Parse(conAbilityScoreTextBox.Text), int.Parse(levelTextBox.Text)).ToString();
        }
        // --------------Dex Mod-------------
        private void dexAbilityScoreTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dexAbilityScoreTextBox.Text))
                dexAbilityScoreTextBox.Text = "0";
            else
                dexAbilityModTextBox.Text = getMod(int.Parse(dexAbilityScoreTextBox.Text)).ToString();
                dexModTotalTextBox.Text = (getMod(int.Parse(dexAbilityScoreTextBox.Text)) + getHalfLevel()).ToString();
        }
        // -----------------Int Mod--------------
        private void intAbilityScoreTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(intAbilityScoreTextBox.Text))
                intAbilityScoreTextBox.Text = "0";
            else
                intAbilityModTextBox.Text = getMod(int.Parse(intAbilityScoreTextBox.Text)).ToString();
                intModTotalTextBox.Text = getModTotal(int.Parse(intAbilityScoreTextBox.Text), int.Parse(levelTextBox.Text)).ToString();
        }
        // ---------------Wis Mod--------------
        private void wisAbilityScoreTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(wisAbilityScoreTextBox.Text))
                wisAbilityScoreTextBox.Text = "0";
            else
                wisAbilityModTextBox.Text = getMod(int.Parse(wisAbilityScoreTextBox.Text)).ToString();
                wisModTotalTextBox.Text = getModTotal(int.Parse(wisAbilityScoreTextBox.Text), int.Parse(levelTextBox.Text)).ToString();
        }
        //----------------Cha Mod---------------------
        private void chaAbilityScoreTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(chaAbilityScoreTextBox.Text))
                chaAbilityScoreTextBox.Text = "0";
            else
                chaAbilityModTextBox.Text = getMod(int.Parse(chaAbilityScoreTextBox.Text)).ToString();
                chaModTotalTextBox.Text = getModTotal(int.Parse(chaAbilityScoreTextBox.Text), int.Parse(levelTextBox.Text)).ToString();
        }
        /****************** End get ability mod values via text change ***************/

        /****************** Initiave Section **********************/
        
        private void initiaveDexTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void initiaveHalfLevelTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void initiaveMiscTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        /****************** End Initiave Section ******************/

        /***************** Save and load files *******************/
        private void loadButton_Click(object sender, EventArgs e)
        {
            loadDndFile();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            saveDndFile();
        }
        /****************End Save and load section ***************/










        //Exit Button close check

        private void exitButton_Click(object sender, EventArgs e)
        {
            closeCheck();
        }




        //Helper  Meathods
        private void closeCheck()
        {
            if (MessageBox.Show("Are you sure you want to EXIT, all unsaved data will be lost!", "Exit",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) this.Close();
        }
        private int getMod(int abilityScore)
        { 
            int abilityMod = (abilityScore / 2) - 5;
            return abilityMod;
        }
        private int getModTotal(int abilityScore, int level)
        {
            //double tempTotalAbility = abilityMod * 0.5;
            //int totalAbility = (int)tempTotalAbility;
            //return totalAbility;
            int abilityMod = (abilityScore / 2) - 5;
            double tempModTotal = abilityMod + 0.5 * level;
            int modTotal = (int)tempModTotal;
            return modTotal;
        }
        private int getHalfLevel()
        {
            double halfLevel = double.Parse(levelTextBox.Text) * .5;
            int convetedHalfLevel = (int)halfLevel;
            initiaveHelfLevelTextBox.Text = convetedHalfLevel.ToString();
            return convetedHalfLevel;
        }
        private void loadDndFile()
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog1.FileName);

                nameTextBox.Text = lines[0];
                raceTextBox.Text = lines[1];
                sizeTextBox.Text = lines[2];
                ageTextBox.Text = lines[3];
                genderTextBox.Text = lines[4];
                weightTextBox.Text = lines[5];
                heightTextBox.Text = lines[6];
                alignmentTextBox.Text = lines[7];
                deityTextBox.Text = lines[8];
                strAbilityScoreTextBox.Text = lines[9];
                conAbilityScoreTextBox.Text = lines[10];
                dexAbilityScoreTextBox.Text = lines[11];
                intAbilityScoreTextBox.Text = lines[12];
                wisAbilityScoreTextBox.Text = lines[13];
                chaAbilityScoreTextBox.Text = lines[14];

                
            }
        }
        private void saveDndFile()
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] lines = new string[15];
                lines[0] = nameTextBox.Text;
                lines[1] = raceTextBox.Text;
                lines[2] = sizeTextBox.Text;
                lines[3] = ageTextBox.Text;
                lines[4] = genderTextBox.Text;
                lines[5] = weightTextBox.Text;
                lines[6] = heightTextBox.Text;
                lines[7] = alignmentTextBox.Text;
                lines[8] = deityTextBox.Text;
                lines[9] = strAbilityScoreTextBox.Text;
                lines[10] = conAbilityScoreTextBox.Text;
                lines[11] = dexAbilityScoreTextBox.Text;
                lines[12] = intAbilityScoreTextBox.Text;
                lines[13] = wisAbilityScoreTextBox.Text;
                lines[14] = chaAbilityScoreTextBox.Text;
                File.WriteAllLines(openFileDialog1.FileName, lines);
            }
        }
    }
}

