using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staticky_model_pisek
{
    class Auto : Proces
    {
        int dobaJizdy;
        int nosnost;
        int dobaVylozeni;
        int dobaNalozeni;
        Model model;

        public Auto(int dobaJizdy, int nosnost, int dobaVylozeni, int dobaNalozeni, Model model, string jmeno)
        {
            this.dobaJizdy = dobaJizdy;
            this.nosnost = nosnost;
            this.dobaVylozeni = dobaVylozeni;
            this.dobaNalozeni = dobaNalozeni;
            this.model = model;
            this.Jmeno = jmeno;

            model.Naplanuj(model.Cas, TypUdalosti.PrijizdiKLomu, this);
        }

        public override void Zpracuj(int ted, TypUdalosti co)
        {
            switch (co)
            {
                case TypUdalosti.PrijizdiKLomu:
                    if (model.NejblizsiStartNakladani <= ted)
                    {
                        model.Naplanuj(ted, TypUdalosti.ZacinaNakladat, this);
                        model.NejblizsiStartNakladani = ted + this.dobaNalozeni;
                    }
                    else
                    {
                        model.Naplanuj(model.NejblizsiStartNakladani, TypUdalosti.ZacinaNakladat, this);
                        model.NejblizsiStartNakladani += this.dobaNalozeni;
                    }
                    break;
                case TypUdalosti.ZacinaNakladat:
                    model.Naplanuj(ted + dobaNalozeni, TypUdalosti.Nalozeno, this);
                    break;
                case TypUdalosti.Nalozeno:
                    model.Naplanuj(ted + dobaJizdy, TypUdalosti.PrijizdiNaStavbu, this);
                    break;
                case TypUdalosti.PrijizdiNaStavbu:
                    model.Naplanuj(ted + dobaVylozeni, TypUdalosti.Vylozeno, this);
                    break;
                case TypUdalosti.Vylozeno:
                    model.Naplanuj(ted + dobaJizdy, TypUdalosti.PrijizdiKLomu, this);
                    model.PisekNaStavbe += nosnost;
                    break;
                default:
                    break;
            }
        }
    }
}
