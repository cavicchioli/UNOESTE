using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrjIntroducao
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void exercício1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //instanciar o formulario do exercício 1
            FrmExercicio1 fqualquercoisa = new FrmExercicio1();
            

            //exibir o formulario
            fqualquercoisa.ShowDialog();
            

            //destruir o formulario que foi criado
            fqualquercoisa.Dispose();
          
            //ou
            
        }

        private void exercício2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExercicio2 fexercicio2 = new FrmExercicio2();
            fexercicio2.ShowDialog();
            fexercicio2.Dispose();
        }

        private void exercício3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExercicio3 fexercicio3 = new FrmExercicio3();
            fexercicio3.ShowDialog();
            fexercicio3.Dispose();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
