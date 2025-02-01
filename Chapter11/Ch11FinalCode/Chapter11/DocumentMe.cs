using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CloudySkiesAir.Chapter11;

public class DocumentMe {

  /// <summary>
  /// Sumuje liczby parzyste w tabeli
  /// </summary>
  /// <param name="numbers">Tablicza liczb do zsumowania.</param>
  /// <param name="total">Suma początkowa. Domyślnie 0.</param>
  /// <returns>Suma wszystkich parzystych liczb w tablicy.</returns>
  /// <exception cref="ArgumentException">Zgłaszany, gdy tablica jest null lub pusta.</exception>
  public int AddEvenNumbers(int[]? numbers, int total = 0) {
    if (numbers == null || numbers.Length == 0) {
      const string message = "Musi być przynajmniej 1 element";
      throw new ArgumentException(message, nameof(numbers));
    }

    return total + numbers.Where(n => n % 2 == 0).Sum();
  }
}
