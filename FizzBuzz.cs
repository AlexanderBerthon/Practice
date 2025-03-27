using System;

public class FizzBuzz{

	public FizzBuzz(){
	}

	public static string Solve(int number) {
		
		string result = "";

		if ((number % 3 == 0) && (number % 5 == 0)) {
			result = "FizzBuzz";
		}
		else if (number % 3 == 0) {
			result = "Fizz";
		}
		else if (number % 5 == 0) {
			result = "Buzz";
		}
		else {
			result = number.ToString();
		}

		return result;

	}

}
