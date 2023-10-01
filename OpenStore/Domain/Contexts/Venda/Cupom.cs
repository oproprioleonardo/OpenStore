﻿using OpenStore.Domain.Contexts.Venda.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStore.Domain.Contexts.Venda
{
    public class Cupom
    {

        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Cliente { get; set; }
        public bool IsClosed { get; set; }
        public bool IsCanceled { get; set; }
        public List<CupomItem> Items { get; set; }


        public Cupom()
        {
            Cliente = "";
            Items = new List<CupomItem>();
        }

        public Cupom(long id, DateTime date, string cliente, List<CupomItem> items)
        {
            Id = id;
            Date = date;
            Cliente = cliente;
            Items = items;
        }

        public static Cupom NewCupom(long id, DateTime date, string cliente, List<CupomItem> items)
        {
            return new Cupom(id, date, cliente, items);
        }

        public void Close()
        {
            IsClosed = true;
        }

        public void Cancel()
        {
            IsClosed = true;
            IsCanceled = true;
        }

        public decimal GetTotal()
        {
            return Items.ConvertAll(i => i.GetTotal()).Sum();
        }
    }
}
