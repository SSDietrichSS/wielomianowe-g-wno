using WielomianLib;
wLib wLib = new wLib();




#region pools
//listy przyjmujące wartość wielomianu 
List<int> polynomial1 = new List<int>();
List<int> polynomial2 = new List<int>();
//pobieranie wartości wielomianu
#endregion
#region basic stuff to work on 
for (int wielomianNumber = 0; wielomianNumber < 2; wielomianNumber++)
{
ERROR1:/*wykrycie błędu w przypadku wybrania złej wartości w wyborze ilości potęg wielomianu */
    Console.WriteLine("ilość potęg wielomianu nr {0}", wielomianNumber + 1);
    var x = Console.ReadLine();
    bool isnumeric = int.TryParse(x, out int q);
    if (isnumeric)//sprawdzanie czy wartość jest numeryczna
    {
        for (int i = 0; i < q; i++)
        {
        ERROR2:/*wykrycie błędu w przypadku nie numerycznej wartości wprowadzonej  */
            Console.WriteLine("podaj wartość dla x^{0} : ", i);
            bool isnumericforX = int.TryParse(Console.ReadLine(), out int xvalue);//sprawdzanie czy wartość jest numeryczna
            if (isnumericforX)
            {
                switch (wielomianNumber)
                {
                    case 0:
                        polynomial1.Add(xvalue);
                        break;
                    case 1:
                        polynomial2.Add(xvalue);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("podana wartość to nie liczba!");
                goto ERROR2;/*wykrycie błędu w przypadku nie numerycznej wartości wprowadzonej  */
            }
        }
    }
    else
    {
        Console.WriteLine("podana wartość to nie liczba!");
        goto ERROR1;/*wykrycie błędu w przypadku wybrania złej wartości w wyborze ilości potęg wielomianu */
    }
}
#endregion
#region wybór operacji na bibliotece
ERROR3:
Console.WriteLine("wybierz operacje na której chcesz działać");
Console.WriteLine("1 dodawanie" +
    "2 odejmowanie " +
    "3 mnożenie ");
Console.ReadLine();
bool isnumericforZ = int.TryParse(Console.ReadLine(), out int v);
if (isnumericforZ)
{
    switch (v)
    {
        case 1:
            wLib.addingAPolynomial(polynomial1, polynomial2);
            break;
        case 2:
            wLib.PolynomialSubtraction(polynomial1, polynomial2);
            break;
        case 3:
            wLib.MultiplicationOfAPolynomial(polynomial1, polynomial2);
            break;
        default:
            Console.WriteLine("nieprawidłowa wartość");
            break;
    }
}
else
{
    Console.WriteLine("podana wartość to nie liczba!");
    goto ERROR3;
}
#endregion



