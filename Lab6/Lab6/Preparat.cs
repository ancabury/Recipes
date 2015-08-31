using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6 {
	class Preparat {
		public int codC { get; set; }
		public int codP { get; set; }
		public string numeP { get; set; }
		public float pret { get; set; }
		public int timp_prep { get; set; }

		public Preparat() { }
		public Preparat(int c, int p, string n, float pret, int timp) {
			codC = c;
			codP = p;
			numeP = n;
			this.pret = pret;
			timp_prep = timp;
		}

		public override string ToString() {
			return numeP + "\t" + pret.ToString() + "\t" + timp_prep.ToString();
		}
	}
}
