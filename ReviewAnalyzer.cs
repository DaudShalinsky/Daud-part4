using System.Collections.Specialized;
using System.ComponentModel.Design;

public static class ReviewAnalyzer
{

    private static bool CheckForPozitivity(string review)
    {
        string[] positivExpressions = { "прекрасн", "довол", "отличн", "дружелюбн", "великолеп", "рекоменд" };
        foreach (string expression in positivExpressions)
        {
            if (review.ToLower().StartsWith(expression))
            {
                return true;
            }
        }
        return false;
    }

    private static bool CheckForNegativity(string review)
    {
        string[] negativeExpressions = { "ужасн", "разочаров", "неприятн", "не довол" };
        foreach (string excepression in negativeExpressions)
        {
            if (review.ToLower().StartsWith(excepression))
            {
                return true;
            }
        }
        return false;
    }
    public static void Start()
    {
        Console.WriteLine("Напишите отзыв: ");

        string review;

        do
        {
            review = Console.ReadLine();

            bool isPositive = CheckForPozitivity(review);
            bool isNegative = CheckForNegativity(review);

            if (isPositive == true)
            {
                Console.WriteLine("Положитлеьный отзыв.");
            }
            else if (isNegative == true)
            {
                Console.WriteLine("Отрицатльный отзыв.");
            }
            else if (isNegative == false && isPositive == false)
            {
                Console.WriteLine("Нейтральный отзыв.");
            }
        } while (!string.IsNullOrEmpty(review));
    }
}