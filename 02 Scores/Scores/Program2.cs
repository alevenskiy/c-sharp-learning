using System;

namespace Scores
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello. Press Enter to open the table. Please press Space to see the next values");
            Console.ReadLine();

            /*готовим шапку таблицы*/
            string _fullName = "Full Name";
            string _wordAge = "Age";
            string _email = "Email";
            string _wordProgramming = "Programming";
            string _wordMath = "Math";
            string _wordPhisics = "Phisics";
            string _wordAverage = "Average"; 

            /*выводим шапку таблицы
             *после слова Phisic дополнительный пробел, чтобы уровнять таблицу после нажатия пробела перед выводом среднего значения
             */
            string _template = $"{_fullName,30}|{_wordAge,5}|{_email,20}|{_wordProgramming,12}|{_wordMath,5}|{_wordPhisics,8} |{_wordAverage, 8}";
            Console.WriteLine(_template);
            Console.ReadKey();
            Console.WriteLine();/*дожидаемся нажатия кнопки и переносим строку*/


            #region первый человек
            /*готовим человека*/
            _fullName = "Alexander Rozhdestvenskiy";
            int _age = 24;
            _email = "ppcrn@gmail.com";
            float _scoresProgramming = 7.7f;
            float _scoresMath = 7.2f;
            float _scoresPhisics = 5.4f;

            /*считаем среднее*/
            float _scoresSum = _scoresProgramming + _scoresMath + _scoresPhisics;
            float _scoresAverage = _scoresSum / 3;

            /*выводим человека*/
            _template = $"{_fullName,30}|{_age,5}|{_email,20}|{_scoresProgramming,12}|{_scoresMath,5}|{_scoresPhisics,8}";
            Console.Write(_template);
            Console.ReadKey();/*дожидаемся нажатия кнопки*/

            /*выводим среднее*/
            Console.Write($"|{ _scoresAverage, 7:0.00}"); /*здесь на ячейку 7 символов, а не 8, потому что 8й пробел ставит юзер, пытаясь открыть ячайку*/
            Console.ReadKey();
            Console.WriteLine();/*дожидаемся нажатия кнопки и переносим строку*/
            #endregion

            #region второй человек
            /*готовим человека*/
            _fullName = "A A";
            _age = 1;
            _email = "a@a.com";
            _scoresProgramming = 1.7f;
            _scoresMath = 7.1f;
            _scoresPhisics = 1.1f;

            /*считаем среднее*/
            _scoresSum = _scoresProgramming + _scoresMath + _scoresPhisics;
            _scoresAverage = _scoresSum / 3;

            /*выводим человека*/
            _template = $"{_fullName,30}|{_age,5}|{_email,20}|{_scoresProgramming,12}|{_scoresMath,5}|{_scoresPhisics,8}";
            Console.Write(_template);
            Console.ReadKey();/*дожидаемся нажатия кнопки*/

            /*выводим среднее*/
            Console.Write($"|{ _scoresAverage,7:0.00}");
            Console.ReadKey();
            Console.WriteLine();/*дожидаемся нажатия кнопки и переносим строку*/
            #endregion

            #region третий человек
            /*готовим человека*/
            _fullName = "Б Б";
            _age = 2;
            _email = "b@b.com";
            _scoresProgramming = 2.7f;
            _scoresMath = 7.2f;
            _scoresPhisics = 2.2f;

            /*считаем среднее*/
            _scoresSum = _scoresProgramming + _scoresMath + _scoresPhisics;
            _scoresAverage = _scoresSum / 3;

            /*выводим человека*/
            _template = $"{_fullName,30}|{_age,5}|{_email,20}|{_scoresProgramming,12}|{_scoresMath,5}|{_scoresPhisics,8}";
            Console.Write(_template);
            Console.ReadKey();/*дожидаемся нажатия кнопки*/

            /*выводим среднее*/
            Console.Write($"|{ _scoresAverage,7:0.00}");
            Console.ReadKey();
            Console.WriteLine();/*дожидаемся нажатия кнопки и переносим строку*/
            #endregion

            #region четвертый человек
            /*готовим человека*/
            _fullName = "В В";
            _age = 3;
            _email = "v@v.com";
            _scoresProgramming = 3.7f;
            _scoresMath = 7.3f;
            _scoresPhisics = 3.3f;

            /*считаем среднее*/
            _scoresSum = _scoresProgramming + _scoresMath + _scoresPhisics;
            _scoresAverage = _scoresSum / 3;

            /*выводим человека*/
            _template = $"{_fullName,30}|{_age,5}|{_email,20}|{_scoresProgramming,12}|{_scoresMath,5}|{_scoresPhisics,8}";
            Console.Write(_template);
            Console.ReadKey();/*дожидаемся нажатия кнопки*/

            /*выводим среднее*/
            Console.Write($"|{ _scoresAverage,7:0.00}");
            Console.ReadKey();
            Console.WriteLine();/*дожидаемся нажатия кнопки и переносим строку*/
            #endregion

            Console.WriteLine();
            Console.WriteLine("Thats all. Press Enter to close the table");
            Console.ReadLine();
        }
    }
}
