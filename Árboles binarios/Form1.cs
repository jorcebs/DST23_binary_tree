using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Árboles_binarios
{
    public partial class Form1 : Form
    {

        Árbol tree = new Árbol();

        public Form1()
        {
            tree.Agregar(new Nodo(6));
            tree.Agregar(new Nodo(2));
            tree.Agregar(new Nodo(1));
            tree.Agregar(new Nodo(4));
            tree.Agregar(new Nodo(3));
            tree.Agregar(new Nodo(5));
            tree.Agregar(new Nodo(7));
            tree.Agregar(new Nodo(9));
            tree.Agregar(new Nodo(8));
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            tree.Agregar(new Nodo(Convert.ToInt32(txtDato.Text)));
            txtResultado.Text = "Nodo agregado";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Nodo nodo = tree.Buscar(Convert.ToInt32(txtDato.Text));
            txtResultado.Text = (nodo != null) ? "Nodo encontrado: " + nodo.ToString() : "Nodo no encontrado";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {  
            txtResultado.Text = (tree.Eliminar(Convert.ToInt32(txtDato.Text))) ? "Nodo eliminado" : "Nodo no encontrado";
        }

        private void btnPreOrder_Click(object sender, EventArgs e)
        {
            txtResultado.Text = tree.PreOrder().Remove(tree.PreOrder().Length - 1);
        }

        private void btnInOrder_Click(object sender, EventArgs e)
        {
            txtResultado.Text = tree.InOrder().Remove(tree.InOrder().Length - 1);
        }

        private void btnPostOrder_Click(object sender, EventArgs e)
        {
            txtResultado.Text = tree.PostOrder().Remove(tree.PostOrder().Length - 1);
        }
    }
}