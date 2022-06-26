namespace WielomianLib;
public class wLib
{
    #region PolynomialObject

    private class PolynomialObject
    {/// <summary>
     /// tworzy obiekt w pamięci przechowując wartości liczbowe
     /// </summary>
     /// <param name="value">przechowuje wartość przed X </param>
     /// <param name="impressiveness"> przechowuje potęgę </param>
        public PolynomialObject(int value, int impressiveness)
        {
            this.impressiveness = impressiveness;
            this.value = value;

        }
        public int value { get; set; }
        public int impressiveness { get; set; }

    }
    #endregion
    #region addingAPolynomial
    /// <summary>
    /// dodaje dwa wielomiany
    /// </summary>
    /// <param name="xlist">pobiera pierwszy wielomian</param>
    /// <param name="zlist"> pobiera 2 wielomian </param>
    public void addingAPolynomial(List<int> xlist, List<int> zlist)
    {
        List<int> list = new List<int>();
        //jeżeli pierwszy wielomian jest większy to wykonuje tę operację jako pierwszą
        if (xlist.Count > zlist.Count)
        {
            for (int i = 0; i < xlist.Count; i++)
            {
                if (i < zlist.Count)
                {
                    list.Add(zlist.ElementAt(i) + xlist.ElementAt(i));
                }
                else
                {
                    list.Add(xlist.ElementAt(i));
                }
            }
        }
        else//jeżeli drugi wielomian jest większy to wykonuje tę operację jako pierwszą
        {
            for (int i = 0; i < zlist.Count; i++)
            {
                if (i < xlist.Count)
                {
                    list.Add(zlist.ElementAt(i) + xlist.ElementAt(i));

                }
                else
                {
                    list.Add(zlist.ElementAt(i));
                }
            }
        }
        //przekazuje wielomian do wyświetlenia
        HumanUnderstableConverter(list);
    }
    #endregion
    #region PolynomialSubtraction
    /// <summary>
    /// odejmuje dwa wielomiany
    /// </summary>
    /// <param name="xlist">pobiera pierwszy wielomian</param>
    /// <param name="zlist"> pobiera 2 wielomian </param>
    public void PolynomialSubtraction(List<int> xlist, List<int> zlist)
    {
        List<int> list = new List<int>();
        //jeżeli pierwszy wielomian jest większy to wykonuje tę operację jako pierwszą
        if (xlist.Count > zlist.Count)
        {
            for (int i = 0; i < xlist.Count; i++)
            {
                if (i < zlist.Count)
                {
                    list.Add(zlist.ElementAt(i) - xlist.ElementAt(i));
                }
                else
                {
                    list.Add(xlist.ElementAt(i));
                }
            }
        }
        else//jeżeli drugi wielomian jest większy to wykonuje tę operację jako pierwszą
        {
            for (int i = 0; i < zlist.Count; i++)
            {
                if (i < xlist.Count)
                {
                    list.Add(zlist.ElementAt(i) - xlist.ElementAt(i));

                }
                else
                {
                    list.Add(zlist.ElementAt(i));
                }
            }
        }
        //przekazuje wielomian do wyświetlenia 
        HumanUnderstableConverter(list);
    }
    #endregion
    #region MultiplicationOfAPolynomial
    /// <summary>
    /// pozwala na mnożenie wielomianu i zwraca jego obliczoną wartość.
    /// </summary>
    /// <param name="xlist">list of wielomian values</param>
    /// <param name="zlist">list of wielomian values</param>
    public void MultiplicationOfAPolynomial(List<int> xlist, List<int> zlist)
    {

        /*temp lists and value*/
        IList<PolynomialObject> list = new List<PolynomialObject>();
        IList<PolynomialObject> list2 = new List<PolynomialObject>();
        IList<PolynomialObject> list3 = new List<PolynomialObject>();
        IList<PolynomialObject> list4 = new List<PolynomialObject>();
        List<int> finish = new List<int>();
        int temp = 0;
        /*end temp lists and value*/

        // przekazywanie wartości pierwszego wielomianu do obiektu 
        for (int i = 0; i < xlist.Count; i++)
        {
            list.Add(new PolynomialObject(xlist[i], i));
        }
        // przekazywanie wartości drugiego wielomianu do obiektu 
        for (int i = 0; i < zlist.Count; i++)
        {
            list2.Add(new PolynomialObject(zlist[i], i));
        }
        // operacja mnożenia obiektów (wielomianów)
        foreach (var iteml1 in list)
        {
            foreach (var iteml2 in list2)
            {
                list3.Add(new PolynomialObject(iteml1.value * iteml2.value, iteml1.impressiveness + iteml2.impressiveness));
            }
        }
        //ustalanie najwyższej potęgi
        foreach (var item3 in list3)
        {
            if (item3.impressiveness > temp)
            {
                temp = item3.impressiveness;
            }
        }
        //układanie listy według potęgi dla łatwiejszej konwersji na listę typów
        for (int i = 0; i < temp + 1; i++)
        {
            list4.Add(new PolynomialObject(0, i));
        };

        //łączenie wielomianów według potęgi
        for (int i = 0; i < list4.Count; i++)
        {
            for (int x = 0; x < list3.Count; x++)
            {
                if (list3[x].impressiveness == list4[i].impressiveness)
                {
                    list4[i].value = list4[i].value + list3[x].value;
                }
            }
        }
        //konwersja stosu obiektów na stos wartości
        foreach (var item in list4)
        {
            finish.Add(item.value);
        }
        //przekazanie stosu wartości do generatora czytelnego wielomianu 
        HumanUnderstableConverter(finish);
    }
    #endregion
    #region HumanUnderstableConverter
    /// <summary>
    /// przyjmuje wielomian w celu wypisania go w bardziej ludzkiej formie
    /// </summary>
    /// <param name="xlist">przyjmuje wielomian w celu wypisania go w bardziej ludzkiej formie ;) </param>
    private void HumanUnderstableConverter(List<int> xlist)
    {
        Console.WriteLine("twój nowy wielomian to:");
        var Wlenght = xlist.Count();
        List<int> revlist = new List<int>();
        revlist = Enumerable.Reverse(xlist).ToList();
        for (int i = 0; i < revlist.Count - 1; i++)
        {
            string element;
            if (revlist.ElementAt(i) >= 0)
            {
                element = "+" + revlist.ElementAt(i);
            }
            else
            {
                element = revlist.ElementAt(i).ToString();
            }
            Console.Write("{0}x^{1}  ", element, Wlenght - 1);
            Wlenght--;
        }
        if (revlist.Last() >= 0)
        {
            Console.Write("+" + revlist.Last() + "x");
        }
        else
        {
            Console.Write(revlist.Last() + "x");
        }
    }

    #endregion

}
