using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThoiTrang
{
    public class XCart
    {
        public List<CartItem> Add(CartItem cartitem, int id)
        {
            List<CartItem> listcart;
            if (System.Web.HttpContext.Current.Session["MyCart"].Equals(""))
            {
                listcart = new List<CartItem>();
                listcart.Add(cartitem);
                System.Web.HttpContext.Current.Session["MyCart"] = listcart;
            }
            else
            {
                listcart = (List<CartItem>)System.Web.HttpContext.Current.Session["MyCart"];//Ép kiểu về list
                //Kiểm tra id có tồn tại trong danh sách
                if (listcart.Where(m => m.Id == id).Count() != 0)
                {
                    int vt = 0;
                    foreach (var item in listcart)
                    {
                        if (item.Id == id)
                        {
                            listcart[vt].Qty += 1;
                            listcart[vt].Amount += listcart[vt].Price;
                        }
                        vt++;
                    }
                    System.Web.HttpContext.Current.Session["MyCart"] = listcart;
                }
                else
                {
                    listcart.Add(cartitem);
                    System.Web.HttpContext.Current.Session["MyCart"] = listcart;
                }
            }
            return listcart;
        }
        public void UpdateCart(string[] arrqty)
        {
            List<CartItem> listcart = this.GetCart();
            int vt = 0;
            foreach (CartItem cartitem in listcart)
            {
                listcart[vt].Qty = int.Parse(arrqty[vt]);
                listcart[vt].Amount = listcart[vt].Price * listcart[vt].Qty;
                vt++;
            }
            System.Web.HttpContext.Current.Session["MyCart"] = listcart;
        }

        public void DelCart(int id)
        {
            if (!System.Web.HttpContext.Current.Session["MyCart"].Equals(""))
            {
                List<CartItem> listcart = (List<CartItem>)System.Web.HttpContext.Current.Session["MyCart"];
                int vt = 0;
                foreach (var item in listcart)
                {
                    if (item.Id == id)
                    {
                        listcart.RemoveAt(vt);
                        break;
                    }
                    vt++;
                }
                System.Web.HttpContext.Current.Session["MyCart"] = listcart;
            }
        }

        public List<CartItem> GetCart()
        {
            if (System.Web.HttpContext.Current.Session["MyCart"].Equals(""))
            {
                return null;
            }
                return (List<CartItem>)System.Web.HttpContext.Current.Session["MyCart"];
        }
    }
}