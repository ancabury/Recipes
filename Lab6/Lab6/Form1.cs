using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Lab6 {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
			InitializeDB();
		}

		private void InitializeDB() {
			try {
				conn = new System.Data.SqlClient.SqlConnection();
				conn.ConnectionString = sqlConnection1.ConnectionString;
				SqlDataAdapter da = new SqlDataAdapter("select numeC from Categorii", conn);
				DataSet categorii = new DataSet();
				da.Fill(categorii, "categorii");

				DataRowCollection dc = categorii.Tables["categorii"].Rows;
				foreach (DataRow d in dc) {
					comboBoxCategorii.Items.Add(d[0].ToString());
				}
			}
			catch (Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}

		private void clearListBoxPreparate() {
			while (listBoxPreparate.Items.Count > 0)
				listBoxPreparate.Items.RemoveAt(0);
		}

		private void clearTextBoxPrep() {
			textBoxTimpP.Clear();
			textBoxPretP.Clear();
			textBoxNumeP.Clear();
		}

		private void clearComboPrep() {
			while (comboBoxLPr.Items.Count > 0)
				comboBoxLPr.Items.RemoveAt(0);
			comboBoxLPr.SelectedIndex = -1;
			comboBoxLPr.Text = "";
		}

		private void clearListIngrediente() {
			textBoxNumeIn.Clear();
			textBoxUnit.Clear();
			while (comboBoxLPr.Items.Count > 0)
				comboBoxLPr.Items.RemoveAt(0);
			comboBoxLPr.SelectedIndex = -1;
			comboBoxLPr.Text = "";
			listViewReteta.Items.Clear();
		}


		private void comboBoxCategorii_SelectedIndexChanged(object sender, EventArgs e) {
			try {
				clearTextBoxPrep();
				clearListIngrediente();
				clearComboPrep();

				conn = new System.Data.SqlClient.SqlConnection();
				conn.ConnectionString = sqlConnection1.ConnectionString;
				conn.Open();

				cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = "select numeP, pret, timp_preparare from Preparate where codC in (select codC from Categorii where numeC = @numeC)";

				SqlParameter p1 = new SqlParameter();
				p1.ParameterName = "numeC";
				if (comboBoxCategorii.SelectedIndex >= 0)
					p1.Value = comboBoxCategorii.SelectedItem.ToString();
				else
					MessageBox.Show("Nicio categorie selectata.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

				cmd.Parameters.Clear();
				cmd.Parameters.Add(p1);

				SqlDataReader dr;
				dr = cmd.ExecuteReader();
				clearListBoxPreparate();
				while (dr.Read()) {
					Preparat p = new Preparat();
					p.numeP = dr.GetString(0);
					p.pret = (float)dr.GetDouble(1);
					p.timp_prep = dr.GetInt32(2);
					listBoxPreparate.Items.Add(p);
				}

				dr.Close();
				conn.Close();

			}
			catch (Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}

		private void listBoxPreparate_SelectedIndexChanged(object sender, EventArgs e) {
			if (listBoxPreparate.SelectedIndex >= 0) {
				try {
					clearListIngrediente();
					clearTextBoxPrep();
					clearComboPrep();

					conn = new SqlConnection();
					conn.ConnectionString = sqlConnection1.ConnectionString;
					SqlDataAdapter dp = new SqlDataAdapter();
					dp.SelectCommand = new SqlCommand("select codP, codC, numeP, pret, timp_preparare from Preparate", conn);
					DataSet prep = new DataSet();
					dp.Fill(prep, "preparate");

					SqlDataAdapter di = new SqlDataAdapter();
					di.SelectCommand = new SqlCommand("select i.numeI, r.cantitate from Retete r, Ingrediente i where r.codI=i.codI and codP=@codP", conn);

					DataRowCollection dc = prep.Tables["preparate"].Rows;
					Preparat p = new Preparat();

					string s = listBoxPreparate.SelectedItem.ToString();
					string[] fields = s.Split('\t');
					p.numeP = fields[0];
					p.pret = float.Parse(fields[1]);
					p.timp_prep = Convert.ToInt32(fields[2]);

					foreach (DataRow d in dc)
						if (d["numeP"].ToString() == p.numeP) {
							textBoxNumeP.Text = p.numeP;
							textBoxPretP.Text = p.pret.ToString();
							textBoxTimpP.Text = p.timp_prep.ToString();

							di.SelectCommand.Parameters.AddWithValue("codP", d["codP"]);
							break;
						}

					DataSet ingr = new DataSet();
					di.Fill(ingr, "ingrediente");
					dc = ingr.Tables["ingrediente"].Rows;
					foreach (DataRow d in dc) {
						string[] row = { d["numeI"].ToString(), d["cantitate"].ToString() };
						var item = new ListViewItem(row);
						listViewReteta.Items.Add(item);
					}

				}
				catch (Exception ex) {
					MessageBox.Show(ex.ToString());
				}
			}
			else
				clearTextBoxPrep();


		}

		private void listViewReteta_SelectedIndexChanged(object sender, EventArgs e) {
			try {
				conn = new SqlConnection();
				conn.ConnectionString = sqlConnection1.ConnectionString;
				SqlDataAdapter di = new SqlDataAdapter();
				di.SelectCommand = new SqlCommand("select codI, numeI, unitate_masura from Ingrediente", conn);
				DataSet ingr = new DataSet();
				di.Fill(ingr, "ingrediente");

				DataRowCollection dc = ingr.Tables["ingrediente"].Rows;
				ListView.SelectedListViewItemCollection list = listViewReteta.SelectedItems;
				string s = null;
				foreach (ListViewItem i in list)
					s = i.SubItems[0].Text;

				DataSet retete = new DataSet();
				SqlDataAdapter dr = new SqlDataAdapter();
				dr.SelectCommand = new SqlCommand("select p.numeP from Retete r, Preparate p where codI=@codI and p.codP=r.codP ", conn);
				bool exists = false;
				foreach (DataRow d in dc) {
					if (d["numeI"].ToString() == s) {
						textBoxNumeIn.Text = d["numeI"].ToString();
						textBoxUnit.Text = d["unitate_masura"].ToString();

						dr.SelectCommand.Parameters.AddWithValue("codI", d["codI"]);
						exists = true;
						break;
					}
				}

				clearComboPrep();
				if (exists) {
					dr.Fill(retete, "retete");
					dc = retete.Tables["retete"].Rows;
					foreach (DataRow d in dc) {
						comboBoxLPr.Items.Add(d["numeP"].ToString());
					}
					comboBoxLPr.SelectedIndex = 0;
				}
			}
			catch (Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}

		private bool validatePreparat() {
			if (textBoxNumeP.Text.ToString() == string.Empty) {
				MessageBox.Show("Numele preparatului nu poate fi vid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			float val;
			if (textBoxPretP.Text.ToString() == string.Empty) {
				MessageBox.Show("Pretul nu poate fi vid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			else if (!float.TryParse(textBoxPretP.Text.ToString(), out val)) {
				MessageBox.Show("Pretul trebuie sa contina doar cifre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			int v;
			if (textBoxTimpP.Text.ToString() == string.Empty) {
				MessageBox.Show("Timpul de preparare nu poate fi vid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			else if (!int.TryParse(textBoxTimpP.Text.ToString(), out v)) {
				MessageBox.Show("Timpul trebuia sa contina doar cifre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		private void buttonAddPr_Click(object sender, EventArgs e) {
			if (validatePreparat()) {
				try {
					conn = new SqlConnection();
					conn.ConnectionString = sqlConnection1.ConnectionString;

					SqlDataAdapter dc = new SqlDataAdapter();
					dc.SelectCommand = new SqlCommand("select codC from Categorii where numeC=@CC", conn);
					dc.SelectCommand.Parameters.AddWithValue("CC", comboBoxCategorii.SelectedItem.ToString());
					DataSet categ = new DataSet();
					dc.Fill(categ, "categorii");
					DataRowCollection rows = categ.Tables["categorii"].Rows;
					string categorie = rows[0]["codC"].ToString();

					SqlDataAdapter dp = new SqlDataAdapter();
					dp.SelectCommand = new SqlCommand("select codC, numeP, pret, timp_preparare from Preparate", conn);

					dp.InsertCommand = new SqlCommand("INSERT INTO Preparate (codC, numeP, pret, timp_preparare) VALUES (@CC, @NP, @P, @T)", conn);
					dp.InsertCommand.Parameters.AddWithValue("CC", categorie);
					dp.InsertCommand.Parameters.AddWithValue("NP", textBoxNumeP.Text);
					dp.InsertCommand.Parameters.AddWithValue("P", textBoxPretP.Text);
					dp.InsertCommand.Parameters.AddWithValue("T", textBoxTimpP.Text);
					DataSet prep = new DataSet();
					dp.Fill(prep, "preparate");

					DataRow d = prep.Tables["preparate"].NewRow();
					d["codC"] = categorie;
					d["numeP"] = textBoxNumeP.Text;
					d["pret"] = textBoxPretP.Text;
					d["timp_preparare"] = textBoxTimpP.Text;
					prep.Tables["preparate"].Rows.Add(d);

					dp.Update(prep, "preparate");
					comboBoxCategorii_SelectedIndexChanged(sender, e);

				}
				catch (Exception ex) {
					MessageBox.Show(ex.ToString());
				}
			}
		}

		private void buttonModifPr_Click(object sender, EventArgs e) {
			if (listBoxPreparate.SelectedIndex >= 0) {
				if (validatePreparat()) {
					try {
						conn = new SqlConnection();
						conn.ConnectionString = sqlConnection1.ConnectionString;

						SqlDataAdapter dc = new SqlDataAdapter();
						dc.SelectCommand = new SqlCommand("select codC from Categorii where numeC=@CC", conn);
						dc.SelectCommand.Parameters.AddWithValue("CC", comboBoxCategorii.SelectedItem.ToString());
						DataSet categ = new DataSet();
						dc.Fill(categ, "categorii");
						DataRowCollection rows = categ.Tables["categorii"].Rows;
						string categorie = rows[0]["codC"].ToString();

						string preparat = listBoxPreparate.SelectedItem.ToString();
						string[] fieldsprep = preparat.Split('\t');
						SqlDataAdapter adap = new SqlDataAdapter();
						adap.SelectCommand = new SqlCommand("select * from Preparate", conn);
						DataSet prep = new DataSet();
						adap.Fill(prep, "allprep");
						DataRowCollection col = prep.Tables["allprep"].Rows;
						string codP = null;
						foreach (DataRow drow in col)
							if (drow["numeP"].ToString() == fieldsprep[0] && drow["pret"].ToString() == fieldsprep[1] && drow["timp_preparare"].ToString() == fieldsprep[2])
								codP = drow["codP"].ToString();

						SqlDataAdapter dp = new SqlDataAdapter();
						dp.SelectCommand = new SqlCommand("select codP, codC, numeP, pret, timp_preparare from Preparate", conn);
						dp.Fill(prep, "preparate");

						dp.UpdateCommand = new SqlCommand("UPDATE Preparate set codC=@CC, numeP=@NP, pret=@P, timp_preparare=@T WHERE codP=@CP", conn);
						dp.UpdateCommand.Parameters.AddWithValue("CC", categorie);
						dp.UpdateCommand.Parameters.AddWithValue("NP", textBoxNumeP.Text);
						dp.UpdateCommand.Parameters.AddWithValue("P", textBoxPretP.Text);
						dp.UpdateCommand.Parameters.AddWithValue("T", textBoxTimpP.Text);
						dp.UpdateCommand.Parameters.AddWithValue("CP", codP);

						col = prep.Tables["preparate"].Rows;
						foreach (DataRow drow in col) {
							if (drow["codP"].ToString() == codP) {
								drow["codC"] = Convert.ToInt32(categorie);
								drow["numeP"] = textBoxNumeP.Text;
								drow["pret"] = float.Parse(textBoxPretP.Text);
								drow["timp_preparare"] = Convert.ToInt32(textBoxTimpP.Text);
								break;
							}
						}

						dp.Update(prep, "preparate");
						comboBoxCategorii_SelectedIndexChanged(sender, e);

					}
					catch (Exception ex) {
						MessageBox.Show(ex.ToString());
					}
				}
			}
			else
				buttonAddPr_Click(sender, e);
		}

		private void buttonDelPr_Click(object sender, EventArgs e) {
			if (listBoxPreparate.SelectedIndex >= 0) {
				if (validatePreparat()) {
					try {
						conn = new SqlConnection();
						conn.ConnectionString = sqlConnection1.ConnectionString;

						SqlDataAdapter dp = new SqlDataAdapter();
						dp.SelectCommand = new SqlCommand("select * from Preparate", conn);
						dp.DeleteCommand = new SqlCommand("delete from Preparate where codP=@CP", conn);
						DataSet prep = new DataSet();
						dp.Fill(prep, "preparate");

						string preparat = listBoxPreparate.SelectedItem.ToString();
						string[] fieldsprep = preparat.Split('\t');
						dp.Fill(prep, "allprep");
						DataRowCollection col = prep.Tables["allprep"].Rows;
						string codP = null;
						foreach (DataRow drow in col)
							if (drow["numeP"].ToString() == fieldsprep[0] && drow["pret"].ToString() == fieldsprep[1] && drow["timp_preparare"].ToString() == fieldsprep[2])
								codP = drow["codP"].ToString();
						dp.DeleteCommand.Parameters.AddWithValue("CP", codP);

						DataRowCollection dc = prep.Tables["preparate"].Rows;
						foreach (DataRow d in dc)
							if (d["codP"].ToString() == codP)
								d.Delete();

						dp.Update(prep, "preparate");
						comboBoxCategorii_SelectedIndexChanged(sender, e);

					}
					catch (Exception ex) {
						MessageBox.Show(ex.ToString());
					}
				}
			}
			else
				MessageBox.Show("Niciun preparat selectat.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private bool validateIngredient() {
			if (textBoxNumeIn.Text.ToString() == string.Empty) {
				MessageBox.Show("Numele ingredientului nu poate fi vid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (textBoxUnit.Text.ToString() == string.Empty) {
				MessageBox.Show("Unitatea de masura a ingredientului nu poate fi vida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if(Regex.IsMatch(textBoxUnit.Text.ToString(),"^[a-zA-Z]&")){
				MessageBox.Show("Unitatea de masura poate contine doar caractere.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		private void buttonAddIn_Click(object sender, EventArgs e) {
			if (validateIngredient()) {
				try {
					conn = new SqlConnection();
					conn.ConnectionString = sqlConnection1.ConnectionString;
					
					DataSet set = new DataSet();
					SqlDataAdapter ingredad = new SqlDataAdapter();
					ingredad.SelectCommand = new SqlCommand("select * from Ingrediente", conn);
					ingredad.InsertCommand = new SqlCommand("INSERT INTO Ingrediente (numeI, unitate_masura) VALUES (@n, @u)", conn);
					ingredad.Fill(set, "ingrediente");

					ingredad.InsertCommand.Parameters.AddWithValue("n", textBoxNumeIn.Text);
					ingredad.InsertCommand.Parameters.AddWithValue("u", textBoxUnit.Text);

					DataRow d = set.Tables["ingrediente"].NewRow();
					d["numeI"] = textBoxNumeIn.ToString();
					d["unitate_masura"] = textBoxUnit.Text;
					set.Tables["ingrediente"].Rows.Add(d);
					ingredad.Update(set, "ingrediente");
					MessageBox.Show("Ingredient adaugat cu succes.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

				}
				catch (Exception ex) {
					MessageBox.Show(ex.ToString());
				}
			}
		}

		private void buttonModifIn_Click(object sender, EventArgs e) {
			if (listViewReteta.SelectedItems.Count > 0) {
				if (validateIngredient()) {
					try {
						conn = new SqlConnection();
						conn.ConnectionString = sqlConnection1.ConnectionString;

						DataSet set = new DataSet();
						SqlDataAdapter ingredad = new SqlDataAdapter();
						ingredad.SelectCommand = new SqlCommand("select * from Ingrediente", conn);
						ingredad.Fill(set, "ingrediente");

						SqlDataAdapter retetead = new SqlDataAdapter();
						retetead.SelectCommand = new SqlCommand("select * from Retete", conn);
						retetead.Fill(set, "retete");

						string codI = null;
						ListView.SelectedListViewItemCollection list = listViewReteta.SelectedItems;
						string[] s = new string[2];
						foreach (ListViewItem i in list) {
							s[0] = i.SubItems[0].Text;
							s[1] = i.SubItems[1].Text;
						}

						SqlDataAdapter prepad = new SqlDataAdapter();
						prepad.SelectCommand = new SqlCommand("select * from Preparate", conn);
						prepad.Fill(set, "preparate");

						DataRowCollection dc = set.Tables["ingrediente"].Rows;
						foreach (DataRow d in dc)
							if (d["numeI"].ToString() == s[0])
								codI = d["codI"].ToString();

						ingredad.UpdateCommand = new SqlCommand("UPDATE Ingrediente SET numeI=@NI, unitate_masura=@UI where codI=@CI", conn);
						ingredad.UpdateCommand.Parameters.AddWithValue("NI", textBoxNumeIn.Text);
						ingredad.UpdateCommand.Parameters.AddWithValue("UI", textBoxUnit.Text);
						ingredad.UpdateCommand.Parameters.AddWithValue("CI", codI);

						dc = set.Tables["ingrediente"].Rows;
						foreach (DataRow d in dc)
							if (d["codI"].ToString() == codI) {
								d["numeI"] = textBoxNumeIn.Text;
								d["unitate_masura"] = textBoxUnit.Text;
							}

						ingredad.Update(set, "ingrediente");
						MessageBox.Show("Ingredient modificat cu succes.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
						clearListIngrediente();
						clearTextBoxPrep();
					}
					catch (Exception ex) {
						MessageBox.Show(ex.ToString());
					}
				}
			}
			else
				MessageBox.Show("Selectati un ingredient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void buttonDelIn_Click(object sender, EventArgs e) {
			if (validateIngredient()) {
				try {
					conn = new SqlConnection();
					conn.ConnectionString = sqlConnection1.ConnectionString;

					DataSet set = new DataSet();
					SqlDataAdapter ingrad = new SqlDataAdapter();
					ingrad.SelectCommand = new SqlCommand("select * from Ingrediente", conn);
					ingrad.DeleteCommand = new SqlCommand("delete from Ingrediente where codI=@CI", conn);
					ingrad.Fill(set, "ingrediente");

					SqlDataAdapter retetead = new SqlDataAdapter();
					retetead.SelectCommand = new SqlCommand("select * from Retete", conn);
					retetead.DeleteCommand = new SqlCommand("delete from Retete where codI=@CI", conn);
					retetead.Fill(set, "retete");

					string codI = null;
					DataRowCollection dc = set.Tables["ingrediente"].Rows;
					foreach (DataRow d in dc)
						if (d["numeI"].ToString() == textBoxNumeIn.Text && d["unitate_masura"].ToString() == textBoxUnit.Text) {
							codI = d["codI"].ToString();
							break;
						}
					retetead.DeleteCommand.Parameters.AddWithValue("CI", codI);
					ingrad.DeleteCommand.Parameters.AddWithValue("CI", codI);

					dc = set.Tables["retete"].Rows;
					bool exists = false;
					foreach (DataRow d in dc)
						if (d["codI"].ToString() == codI)
							exists = true;

					if (!exists) {
						bool find = false;
						dc = set.Tables["ingrediente"].Rows;
						foreach (DataRow d in dc)
							if (d["codI"].ToString() == codI) {
								find = true;
								d.Delete();
								break;
							}
						if (!find)
							MessageBox.Show("Ingredientul nu exista.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						else {
							ingrad.Update(set, "ingrediente");
							MessageBox.Show("Ingredientul a fost sters cu succes", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
							clearListIngrediente();
							clearTextBoxPrep();
						}
					}
					else
						MessageBox.Show("Acest ingredient nu poate fi sters.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				catch (Exception ex) {
					MessageBox.Show(ex.ToString());
				}
			}
		}

		private void buttonAddInR_Click(object sender, EventArgs e) {
			MessageBox.Show("Introduceti cantitatea","", MessageBoxButtons.OK, MessageBoxIcon.Information);
			textBoxCantitate.Clear();
			textBoxCantitate.Visible = true;
			labelCantitatea.Visible = true;
			textBoxCantitate.Focus();
		}

		private void textBoxCantitate_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				if (listViewReteta.SelectedItems.Count >= 0) {
					if (validateIngredient()) {
						clearComboPrep();
						try {
							conn = new SqlConnection();
							conn.ConnectionString = sqlConnection1.ConnectionString;

							DataSet set = new DataSet();
							SqlDataAdapter ingrad = new SqlDataAdapter();
							ingrad.SelectCommand = new SqlCommand("select * from Ingrediente", conn);
							ingrad.InsertCommand = new SqlCommand("INSERT INTO Ingrediente (numeI, unitate_masura) VALUES (@n, @u)", conn);
							ingrad.Fill(set, "ingrediente");

							SqlDataAdapter retetead = new SqlDataAdapter();
							retetead.SelectCommand = new SqlCommand("select * from Retete", conn);
							retetead.InsertCommand = new SqlCommand("INSERT INTO Retete (codP, codI, cantitate) VALUES (@CP, @CI, @C)", conn);
							retetead.Fill(set, "retete");

							string codP = null;
							SqlDataAdapter prepad = new SqlDataAdapter();
							prepad.SelectCommand = new SqlCommand("select * from Preparate", conn);
							prepad.Fill(set, "preparate");

							DataRowCollection dc = set.Tables["preparate"].Rows;
							foreach (DataRow d in dc)
								if (d["numeP"].ToString() == textBoxNumeP.Text.ToString() && d["pret"].ToString() == textBoxPretP.Text.ToString()
									&& d["timp_preparare"].ToString() == textBoxTimpP.Text.ToString()) {
									codP = d["codP"].ToString();
									break;
								}

							//caut daca ingredientul este in lista de ingrediente
							dc = set.Tables["ingrediente"].Rows;
							string codI = null;
							foreach (DataRow d in dc)
								if (d["numeI"].ToString() == textBoxNumeIn.Text.ToString() && d["unitate_masura"].ToString() == textBoxUnit.Text.ToString()) {
									codI = d["codI"].ToString();
									break;
								}

							if (codI != null) {
								//verific daca ingredientul a fost introdus deja in reteta
								dc = set.Tables["retete"].Rows;
								bool exists = false;
								foreach (DataRow d in dc)
									if (d["codI"].ToString() == codI && d["codP"].ToString() == codP) {
										exists = true;
										break;
									}

								if (exists) {
									MessageBox.Show("Ingredientul a fost introdus deja in reteta", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
									textBoxUnit.Clear();
									textBoxNumeIn.Clear();
									return;
								}
							}
							else {
								//adaug un nou ingredient in lista
								ingrad.InsertCommand.Parameters.AddWithValue("n", textBoxNumeIn.Text);
								ingrad.InsertCommand.Parameters.AddWithValue("u", textBoxUnit.Text);
								DataRow d = set.Tables["ingrediente"].NewRow();
								d["numeI"] = textBoxNumeIn.Text;
								d["unitate_masura"] = textBoxUnit.Text;
								set.Tables["ingrediente"].Rows.Add(d);

								ingrad.Update(set, "ingrediente");
							}

							//adaug ingredientul in reteta
							int cod = -1;
							if (codI == null) {
								dc = set.Tables["ingrediente"].Rows;
								foreach (DataRow d in dc) {
									if (d["numeI"].ToString() == textBoxNumeIn.Text.ToString() && d["unitate_masura"].ToString() == textBoxUnit.Text.ToString()) {
										codI = d["codI"].ToString();
										break;
									}
									cod = Convert.ToInt32(d["codI"]) + 1;
								}
								codI = cod.ToString();
							}
	
							retetead.InsertCommand.Parameters.AddWithValue("CP", codP);
							retetead.InsertCommand.Parameters.AddWithValue("CI", codI);
							retetead.InsertCommand.Parameters.AddWithValue("C", textBoxCantitate.Text);
							DataRow row = set.Tables["retete"].NewRow();
							row["codI"] = Convert.ToInt32(codI);
							row["codP"] = Convert.ToInt32(codP);
							row["cantitate"] = textBoxCantitate.Text;
							set.Tables["retete"].Rows.Add(row);

							retetead.Update(set, "retete");

							textBoxCantitate.Visible = false;
							labelCantitatea.Visible = false;
							listBoxPreparate_SelectedIndexChanged(sender, e);
						}
						catch (Exception ex) {
							MessageBox.Show(ex.ToString());
						}
					}
				}
				else
					MessageBox.Show("Niciun preparat selectat", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonDelFromR_Click(object sender, EventArgs e) {
			if (listViewReteta.SelectedItems.Count > 0) {
				try {
					conn = new SqlConnection();
					conn.ConnectionString = sqlConnection1.ConnectionString;

					DataSet set = new DataSet();
					SqlDataAdapter retetead = new SqlDataAdapter();
					retetead.SelectCommand = new SqlCommand("select * from Retete", conn);
					retetead.DeleteCommand = new SqlCommand("delete from Retete where codI=@CI and codP=@CP", conn);
					retetead.Fill(set, "retete");

					//gasire codP
					string codP = null;
					SqlDataAdapter prepad = new SqlDataAdapter();
					prepad.SelectCommand = new SqlCommand("select * from Preparate", conn);
					prepad.Fill(set, "preparate");

					DataRowCollection dc = set.Tables["preparate"].Rows;
					foreach (DataRow d in dc)
						if (d["numeP"].ToString() == textBoxNumeP.Text.ToString() && d["pret"].ToString() == textBoxPretP.Text.ToString()
							&& d["timp_preparare"].ToString() == textBoxTimpP.Text.ToString()) {
							codP = d["codP"].ToString();
							break;
						}

					//gasire codI
					SqlDataAdapter ingredad = new SqlDataAdapter();
					ingredad.SelectCommand = new SqlCommand("select * from Ingrediente", conn);
					ingredad.Fill(set, "ingrediente");
					dc = set.Tables["ingrediente"].Rows;
					string codI = null;
					foreach (DataRow d in dc)
						if (d["numeI"].ToString() == textBoxNumeIn.Text.ToString() && d["unitate_masura"].ToString() == textBoxUnit.Text.ToString()) {
							codI = d["codI"].ToString();
							break;
						}

					retetead.DeleteCommand.Parameters.AddWithValue("CI", codI);
					retetead.DeleteCommand.Parameters.AddWithValue("CP", codP);
					dc = set.Tables["retete"].Rows;
					foreach(DataRow d in dc)
						if (d["codI"].ToString() == codI && d["codp"].ToString() == codP) {
							d.Delete();
							break;
						}

					retetead.Update(set, "retete");
					listBoxPreparate_SelectedIndexChanged(sender, e);
				}
				catch (Exception ex) {
					MessageBox.Show(ex.ToString());
				}
			}
			else
				MessageBox.Show("Niciun ingredient selectat.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
