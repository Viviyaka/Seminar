using Microsoft.VisualStudio.TestPlatform.TestHost;
using MergeSort;

namespace MergeTests;

using MergeSort;
using Xunit;

public class UnitTest1
{
    [Fact]  // Tím označujeme, že jde o testovací metodu      
    public void Merge_EqualLengthArrays_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
    {
        // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
        int[] array = { 1, 3, 5, 2, 4, 6 };
        int[] expectedArray = { 1, 2, 3, 4, 5, 6 };
        int left = 0;
        int right = array.Length - 1;
        int middle = left + (right - left) / 2;

        // Act - zavoláme testovanou funkci
        MergeSortClass.Merge(array, left, middle, right);

        // Assert - zkontrolujeme to, co nám funkce vrátila
        Assert.Equal(expectedArray, array);
    }

    [Fact]  // Tím označujeme, že jde o testovací metodu      
    public void Merge_Duplicates_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
    {
        // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
        int[] array = { 1, 3, 5, 5, 2, 3, 3, 6 };
        int[] expectedArray = { 1, 2, 3, 3, 3, 5, 5, 6 };
        int left = 0;
        int right = array.Length - 1;
        int middle = left + (right - left) / 2;

        // Act - zavoláme testovanou funkci
        MergeSortClass.Merge(array, left, middle, right);

        // Assert - zkontrolujeme to, co nám funkce vrátila
        Assert.Equal(expectedArray, array);
    }

    [Fact]
    public void Merge_EqualLengthArrays_ReturnsMergedSortedArrayNula()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
    {
        // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
        int[] array = { 1, 7, 0, 5 };
        int[] expectedArray = { 0, 1, 5, 7 };
        int left = 0;
        int right = array.Length - 1;
        int middle = left + (right - left) / 2;

        // Act - zavoláme testovanou funkci
        MergeSortClass.Merge(array, left, middle, right);

        // Assert - zkontrolujeme to, co nám funkce vrátila
        Assert.Equal(expectedArray, array);
    }

    [Fact]  // Tím označujeme, že jde o testovací metodu      
    public void Merge_NotMiddle_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
    {
        // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
        int[] array = { 1, 3, 5, 9, 2, 3, 6, 8 };
        int[] expectedArray = { 1, 2, 3, 3, 5, 6, 8, 9 };
        int left = 0;
        int right = array.Length - 1;
        int middle = 3;

        // Act - zavoláme testovanou funkci
        MergeSortClass.Merge(array, left, middle, right);

        // Assert - zkontrolujeme to, co nám funkce vrátila
        Assert.Equal(expectedArray, array);
    }

    [Fact]  // Tím označujeme, že jde o testovací metodu      
    public void Merge_NegativeNumbers_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
    {
        // Arrange - nastavme vše co potřebujeme, aby mohла běžet testovaná funkce
        int[] array = { -1, 3, 4, -3, 3, 6 };
        int[] expectedArray = { -3, -1, 3, 3, 4, 6 };
        int left = 0;
        int right = array.Length - 1;
        int middle = left + (right - left) / 2;

        // Act - zavoláme testovanou funkci
        MergeSortClass.Merge(array, left, middle, right);

        // Assert - zkontrolujeme to, co nám funkce vrátila
        Assert.Equal(expectedArray, array);
    }
}