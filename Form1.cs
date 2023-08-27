using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountsApp
{
    public partial class frmAccounts : Form
    { 
        // Declaring a private field with a type List<Account>
        // This will store all types of accounts - checking and savings
        private List<Account> accounts = new List<Account>();
        private Account myAccount;

        public frmAccounts()
        {
            InitializeComponent();
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            // Checks on load.
            // Making sure that rbChecking is Checked and disable necessary textbox
            if(rbChecking.Checked) 
            {
                txtDailyWithdrawLimit.Enabled = true;
                txtInterestRate.Enabled = false;
            }
        }

        private void rbChecking_CheckedChanged(object sender, EventArgs e)
        {
            // If radio button Checking is ticked:
            // Daily Withdraw Limit is enabled
            // Interest Rate is disabled
            if (rbChecking.Checked)
            {
                txtDailyWithdrawLimit.Enabled = true;
                txtInterestRate.Enabled = false;
            }
            // If radio button Savings is ticked:
            // Daily Withdraw Limit is disabled
            // Interest Rate is enabled
            else if (rbSavings.Checked)
            {
                txtDailyWithdrawLimit.Enabled = false;
                txtInterestRate.Enabled = true;
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbChecking.Checked)
                {
                    CheckingAccount newCheckingAccount =
                        new CheckingAccount
                        (
                            Convert.ToInt32(txtAccountNumber.Text),
                            txtClientName.Text,
                            Convert.ToDouble(txtBalance.Text),
                            Convert.ToDouble(txtDailyWithdrawLimit.Text)
                        );

                    accounts.Add(newCheckingAccount);
                }
                else if (rbSavings.Checked)
                {
                    SavingsAccount newSavingsAccount =
                        new SavingsAccount
                        (
                            Convert.ToInt32(txtAccountNumber.Text),
                            txtClientName.Text,
                            Convert.ToDouble(txtBalance.Text),
                            Convert.ToDouble(txtInterestRate.Text)
                        );

                    accounts.Add(newSavingsAccount);
                }

                MessageBox.Show("Account Successfully Created\n" + $"Total Number of Accounts: {accounts.Count()}");
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error. Invalid Data: " + ex.Message);
            }

            ClearControls();
        }

        // Clearing all values
        private void ClearControls()
        {
            txtAccountNumber.Text = "";
            txtClientName.Text = "";
            txtBalance.Text = "";
            txtDailyWithdrawLimit.Text = "";
            txtInterestRate.Text = "";
            rbChecking.Checked = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
                myAccount = null;

                foreach (Account account in accounts)
                {
                    if(Convert.ToInt32(txtSearch.Text) == account.Number)
                    {
                        myAccount = account;
                    }
                }
                
                // If the account is not null. This is to prevent any error.
                if (myAccount != null)
                {
                    txtAccountNumber.Text = myAccount.Number.ToString();
                    txtClientName.Text = myAccount.Name;
                    txtBalance.Text = myAccount.Balance.ToString();

                    if (myAccount.GetType() == typeof(CheckingAccount))
                    {
                        txtDailyWithdrawLimit.Text = ((CheckingAccount)myAccount).Limit.ToString();
                        rbChecking.Checked = true;
                    }
                    else if (myAccount.GetType() == typeof(SavingsAccount))
                    {
                        txtInterestRate.Text = ((SavingsAccount)myAccount).Interest.ToString();
                        rbSavings.Checked = true;
                    }
                }
                else
                {
                    MessageBox.Show("No information found");
                    txtSearch.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No information found: " + ex.Message);
            }
        }
    }
}
