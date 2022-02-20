using System;
using System.Collections.Generic;
using System.Text;

namespace Scores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello. Press Enter to open the table\nPlease press Space or Enter to see the next student");
            Console.ReadLine();

            /*готовим шапку таблицы*/
            string _fullName = "Full Name";
            string _wordAge = "Age";
            string _email = "Email";
            string _wordProgramming = "Programming";
            string _wordMath = "Math";
            string _wordPhisics = "Phisics";

            /*выводим шапку таблицы*/
            string _template = $"{_fullName,30}|{_wordAge,5}|{_email,20}|{_wordProgramming,12}|{_wordMath,5}|{_wordPhisics,8}";
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

            /*выводим человека*/
            _template = $"{_fullName,30}|{_age,5}|{_email,20}|{_scoresProgramming,12}|{_scoresMath,5}|{_scoresPhisics,8}";
            Console.Write(_template);
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

            /*выводим человека*/
            _template = $"{_fullName,30}|{_age,5}|{_email,20}|{_scoresProgramming,12}|{_scoresMath,5}|{_scoresPhisics,8}";
            Console.Write(_template);
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

            /*выводим человека*/
            _template = $"{_fullName,30}|{_age,5}|{_email,20}|{_scoresProgramming,12}|{_scoresMath,5}|{_scoresPhisics,8}";
            Console.Write(_template);
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

            /*выводим человека*/
            _template = $"{_fullName,30}|{_age,5}|{_email,20}|{_scoresProgramming,12}|{_scoresMath,5}|{_scoresPhisics,8}";
            Console.Write(_template);
            Console.ReadKey();
            Console.WriteLine();/*дожидаемся нажатия кнопки и переносим строку*/
            #endregion

            Console.WriteLine();
            Console.WriteLine("Thats all. Press Enter to close the table");
            Console.ReadLine();
        }
    }
}
