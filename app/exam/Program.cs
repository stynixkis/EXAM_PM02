string path = "";
double rasch = 0;
string rasstInCm = "";
PrintInputData();

using (StreamReader st = new StreamReader(path))
{
    rasstInCm = st.ReadToEnd();
}

var splitingValueRasstInput = rasstInCm.Split("\n");
double[] resultationRast = new double[splitingValueRasstInput.Length];
for (int i = 0; i < splitingValueRasstInput.Length; i++)
{
    resultationRast[i] = Convert.ToDouble(splitingValueRasstInput[i]);
}

double[,] matrixInchid = new double[,]
{
    {double.MaxValue,resultationRast[0],double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,resultationRast[9],double.MaxValue,double.MaxValue,double.MaxValue },
    {resultationRast[0],double.MaxValue,resultationRast[1],double.MaxValue,double.MaxValue,double.MaxValue,resultationRast[10],double.MaxValue,double.MaxValue,double.MaxValue},
    {double.MaxValue,double.MaxValue,double.MaxValue,resultationRast[2],double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue },
    {double.MaxValue,double.MaxValue,resultationRast[2],double.MaxValue,double.MaxValue,resultationRast[4],double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue },
    {double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,resultationRast[3],double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue },
    {double.MaxValue,double.MaxValue,resultationRast[11],resultationRast[4],resultationRast[3],double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,resultationRast[5] },
    {resultationRast[9],resultationRast[10],double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,resultationRast[8],double.MaxValue,double.MaxValue },
    {double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,resultationRast[8],double.MaxValue,resultationRast[7],double.MaxValue },
    {double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,resultationRast[7],double.MaxValue,resultationRast[6] },
    {double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,resultationRast[5],double.MaxValue,double.MaxValue,resultationRast[6],double.MaxValue }
};

int markOne = 0;
int marSecond = 0;

do
{
    Console.WriteLine( );
    PrintDialogWindow();

    var valueSimmMatrix = Methods.Floyd(matrixInchid);

    //for (int i = 0; i < 10; i++)
    //{
    //    for (int j = 0; j < 10; j++)
    //    {
    //        Console.Write(valueSimmMatrix[i, j]);
    //    }
    //    Console.WriteLine();
    //}

    double cratchRasst = valueSimmMatrix[markOne - 1, marSecond - 1];
    Console.WriteLine($"\nКратчайшее расстояние между точками {markOne} и {marSecond} = {cratchRasst} км");
    var itogRash = (rasch * 100) / cratchRasst;
    Console.WriteLine($"Расход топлива в литрах: {itogRash}");
} while (true);

void PrintInputData()
{
    string valueFileName = "";
    bool flagTrue = true;
    do
    {
        Console.Write("Введите путь и имя файла формата txt: ");
        valueFileName = Console.ReadLine();
        if (string.IsNullOrEmpty(valueFileName.Trim()))
        {
            flagTrue = false;
        }
        else
        {
            var direct = new FileInfo(valueFileName);
            if (!direct.Exists)
            {
                Console.WriteLine("Файл не найден!");
                flagTrue = false;
            }
            if (!direct.ToString().Contains(".txt"))
            {
                Console.WriteLine("Файл с расширением txt!!");
                flagTrue = false;
            }
            else
            {
                using (StreamReader st = new StreamReader(valueFileName))
                {
                    var valueRasst = st.ReadToEnd();
                    if (string.IsNullOrEmpty(valueRasst.Trim()))
                    {
                        Console.WriteLine("Файл пуст!");
                        flagTrue = false;
                    }
                }
                flagTrue = true;
            }
        }
    } while (!flagTrue);
    path = valueFileName.Trim();

    string valueToplivo = "";
    do
    {
        Console.Write("Введите расход топлива в литрах: ");
        valueToplivo = Console.ReadLine();
        if (!string.IsNullOrEmpty(valueToplivo.Trim()))
        {
            if (!double.TryParse(valueToplivo.Trim(), out _))
                flagTrue = false;
            else
                flagTrue = true;
        }
        else
            flagTrue = false;
    } while (!flagTrue);

    rasch = Convert.ToDouble(valueToplivo);
}
void PrintDialogWindow()
{
    bool flagTrue = true;
    string markValue = "";
    do
    {
        Console.Write("Введите точку 1: ");
        markValue = Console.ReadLine();
        if (!string.IsNullOrEmpty(markValue.Trim()))
        {
            if (markValue.Trim() == "#")
            {
                Console.WriteLine("Выход из программы");
                return;
            }
            if (!int.TryParse(markValue.Trim(), out _))
                flagTrue = false;
            else
                flagTrue = true;
        }
        else
            flagTrue = false;
    } while (!flagTrue);

    markOne = Convert.ToInt32(markValue);
    markValue = "";

    do
    {
        Console.Write("Введите точку 2: ");
        markValue = Console.ReadLine();
        if (!string.IsNullOrEmpty(markValue.Trim()))
        {
            if (markValue.Trim() == "#")
            {
                Console.WriteLine("Выход из программы");
                return;
            }
            if (!int.TryParse(markValue.Trim(), out _))
                flagTrue = false;
            else
                flagTrue = true;
        }
        else
            flagTrue = false;
    } while (!flagTrue);

    marSecond = Convert.ToInt32(markValue);
}
