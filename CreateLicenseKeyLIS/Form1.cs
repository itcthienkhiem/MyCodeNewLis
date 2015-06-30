using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CreateLicenseKeyLIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetForm();
        }

        void SetForm()
        {
            ClearKey();
            GetSavedKey();
            CheckValid(txtRegister.Text);
        }
        private void txtSplit_TextChanged(object sender, System.EventArgs e)
        {
            TextBox objText;
            UpdateTextRegister();
            objText = ((TextBox)(sender));
            objText.Text = objText.Text.ToUpper();
            txtSplit_TextChanged(objText);
        }
        private void UpdateTextRegister()
        {
            txtRegister.Text = txtSplit1.Text;
            if (!string.IsNullOrEmpty(txtSplit2.Text))
            {
                txtRegister.Text = (txtRegister.Text + txtSplit2.Text);
            }
            if (!string.IsNullOrEmpty(txtSplit3.Text))
            {
                txtRegister.Text = (txtRegister.Text + txtSplit3.Text);
            }
            if (!string.IsNullOrEmpty(txtSplit4.Text))
            {
                txtRegister.Text = (txtRegister.Text + txtSplit4.Text);
            }
        }
        private bool CheckValid(string p_strUnencryptedKey)
        {
            bool blnIsValid = false;
            string strTextToSave = String.Empty;
            KeyDetails objKey;
            // --- Check that the key is valid
            objKey = WorkObject.ValidateKey(p_strUnencryptedKey);
            if ((!(objKey == null)
                        && objKey.IsValid))
            {
                blnIsValid = true;
                btnSave.Enabled = true;
                if (objKey.Expires)
                {
                    lblRegStatus.ForeColor = Color.Blue;
                    lblRegStatus.Text = "Demo Copy";
                    lblExpires.ForeColor = Color.Blue;
                    lblExpires.Text = ("Expires: " + objKey.DateValidThrough.ToShortDateString());
                }
                else
                {
                    lblRegStatus.ForeColor = Color.Green;
                    lblRegStatus.Text = "Registered Copy.";
                    lblExpires.ForeColor = Color.Green;
                    lblExpires.Text = String.Empty;
                }
            }
            else
            {
                btnSave.Enabled = false;
                lblRegStatus.ForeColor = Color.Red;
                lblRegStatus.Text = "Key Not Valid.";
                lblExpires.ForeColor = Color.Red;
                lblExpires.Text = "Expired.";
            }
            return blnIsValid;
        }
        private void GetSavedKey()
        {
            string strLicenseKey = String.Empty;
            try
            {
                strLicenseKey = WorkObject.GetLicenseKeyFromRegistry();
                if (!string.IsNullOrEmpty(strLicenseKey))
                {
                    txtRegister.Text = strLicenseKey;
                    txtSplit1.Text = strLicenseKey;
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void ClearKey()
        {
            txtSplit1.Text = String.Empty;
            txtSplit2.Text = String.Empty;
            txtSplit3.Text = String.Empty;
            txtSplit4.Text = String.Empty;
            txtRegister.Text = String.Empty;
            CheckValid(txtRegister.Text);
        }
        private void txtSplit_TextChanged(TextBox p_objText)
        {
            string strText = String.Empty;
            if ((txtSplit1.Text.Length > 5))
            {
                strText = WorkObject.StripHyphens(txtSplit1.Text);
                txtSplit1.Text = strText.Substring(0, 5);
                txtSplit2.Text = strText.Substring(5);
            }
            if ((txtSplit2.Text.Length > 5))
            {
                strText = WorkObject.StripHyphens(txtSplit2.Text);
                txtSplit2.Text = strText.Substring(0, 5);
                txtSplit3.Text = strText.Substring(5);
            }
            if ((txtSplit3.Text.Length > 5))
            {
                strText = WorkObject.StripHyphens(txtSplit3.Text);
                txtSplit3.Text = strText.Substring(0, 5);
                txtSplit4.Text = strText.Substring(5);
            }
            if ((txtSplit4.Text.Length > 5))
            {
                strText = WorkObject.StripHyphens(txtSplit4.Text);
                txtSplit4.Text = strText.Substring(0, 5);
            }
            CheckValid(txtRegister.Text);
        }

        private bool SaveKey()
        {
            bool blnReturn = false;

            try
            {
                blnReturn = WorkObject.SaveLicenseKeyToReg(txtRegister.Text, dtpHetHan.Value);
            }
            catch (Exception ex)
            {
                blnReturn = false;
            }
            return blnReturn;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            KeyDetails objKey;
            // Check that the key is valid
            objKey = WorkObject.ValidateKey(txtRegister.Text);
            // ---- only save it if it is valid
            if ((!(objKey == null)
                        && objKey.IsValid))
            {
                if (SaveKey())
                {
                    MessageBox.Show("Your key is valid, and was saved.  Thank you for registering the product.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose(true);
        }
    }
}
