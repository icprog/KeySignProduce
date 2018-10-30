﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace KeySign
{
    
    public partial class MainForm : Form
    {
        Form_AckMake myAckMakeForm = new Form_AckMake();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dateTimePicker_valid_start.Text = (System.DateTime.Now).ToString("yyyy-MM-dd");
            dateTimePicker_valid_end.Text = (System.DateTime.Now.AddYears(1)).ToString("yyyy-MM-dd");
        }


        public int VerifyInfo()
        {
            
            CertInfo.name = textBox_name.Text;



            if (rdo_male.Checked)
                CertInfo.gender = "男";
            else
                CertInfo.gender = "女";

            CertInfo.age = textBox_age.Text;
            CertInfo.phone = textBox_phone.Text; ;
            CertInfo.id = textBox_id.Text;
            CertInfo.email = textBox_mail.Text;
            if (rdo_new.Checked)//发证类型
                CertInfo.issue_type = "新领";
            else
                CertInfo.issue_type = "补证";

            CertInfo.install_type = null;//安装类型
            if (checkBox1.Checked)
                CertInfo.install_type += checkBox1.Text;

            foreach (CheckBox item in panel3.Controls)
            {
                if (item.Checked)
                {
                    CertInfo.install_type += item.Text + ",";
                }
            }
            CertInfo.install_type = CertInfo.install_type.Substring(0, CertInfo.install_type.Length - 1);

            CertInfo.issue_day = dateTimePicker_issue.Text;//发证日期

            CertInfo.cert_validity_period_start = dateTimePicker_valid_start.Text;//证书有效期开始
            CertInfo.cert_validity_period_end = dateTimePicker_valid_end.Text;//证书有效期结束

            CertInfo.project_name = textBox_project_name.Text;
            CertInfo.appid = textBox_appid.Text;
            CertInfo.appkey = textBox_appkey.Text;
            CertInfo.company_name = textBox_company_name.Text;
            CertInfo.company_phone = textBox_company_phone.Text;
            CertInfo.company_address = textBox_company_address.Text;

            CertInfo.remarks = textBox_Remarks.Text;//备注



            //全部通过进入下一个页面，否则提示出错需要重新设置
            if (myAckMakeForm != null)
            {
                myAckMakeForm.Activate();
            }
            else
            {
                myAckMakeForm = new Form_AckMake();
            }
            myAckMakeForm.ShowDialog();

            return 1;
        }

        private void btn_Verify_Click(object sender, EventArgs e)
        {

            try
            {
                VerifyInfo();
               

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}