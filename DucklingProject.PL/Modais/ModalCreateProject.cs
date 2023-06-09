﻿using DucklingProject.BLL;
using DucklingProject.MODEL;
using System.Drawing;

namespace DucklingProject.PL
{
    public partial class ModalCreateProject : Form
    {
        public ModalCreateProject()
        {
            InitializeComponent();
        }

        private void managersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManagerRepository mr = new ManagerRepository();

            mr.GetAll().ForEach(tm =>
            {
                if (!manager_combobox.Items.Contains(tm.ManagerName))
                {
                    manager_combobox.Items.Add(tm.ManagerName);
                }
            });
        }

        private void statusBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            StatusRepository sr = new StatusRepository();

            sr.GetAll().ForEach(ts =>
            {
                if (!status_combobox.Items.Contains(ts.Status))
                {
                    status_combobox.Items.Add(ts.Status);
                }
            });
        }

        private void create_button_Click(object sender, EventArgs e)
        {
            TbProject tbProject = new TbProject();

            try
            {
                ManagerRepository mr = new ManagerRepository();
                StatusRepository sr = new StatusRepository();
                ProjectRepository pr = new ProjectRepository();

                tbProject.IdManager = mr.GetByName(manager_combobox.Text).IdManager;
                tbProject.IdStatus = sr.GetByName(status_combobox.Text).IdStatus;

                tbProject.ProjectDescription = description_textbox.Text;
                tbProject.ProjectName = name_textbox.Text;

                tbProject.DtStart = startdate_picker.Text;
                tbProject.DtFinish = finishdate_picker.Text;

                pr.Add(tbProject);

                MessageBox.Show("Projeto: " + tbProject.ProjectName + " inserido com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TelaPrincipal telaPrincipal = new TelaPrincipal();
            telaPrincipal.projectsLog();
        }

        private void manageradd_button_Click(object sender, EventArgs e)
        {
            ModalManager ms = new ModalManager();
            ms.Show();
        }

        private void statusadd_button_Click(object sender, EventArgs e)
        {
            ModalStatus ms = new ModalStatus();
            ms.Show();
        }

    }
}
