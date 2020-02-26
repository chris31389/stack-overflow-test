# Stack Overflow Test

This is a git repository to track a technical test.  The technical test asks for a console application to be created which can take a date as input, work out some values, then output then in the console application.

## Build

You will need to have Visual Studio 2019 installed

## Run

You can run the application and supply a date in a yyyy-MM-dd format.

## Testing

Please make sure that before any merges to the master branch, all tests are run and succeed.  

- Unit test projects use the NUnit framework
- One integration test runs SpecFlow tests to test the console app end-to-end.

### References

- [SpecFlow](https://specflow.org/)

## Question Feedback

With the first question, I initially used the in-built filter `total` to return the total questions for the day.  But after seeing question 3, which asks to return all tags for the day in a distinctive list, I knew I would need to get all the question items anyway, so I refactored my code to do one set of API calls, and then process them together to produce the answers to all the questions.  I feel this is more efficent.

Question 2 confused me because I noticed that it asked for __all__ question items, where question 1 and 3 asked for the question items for the date supplied.  If this was a real life project, I would look to clarify what was asked and implement what was desired.  For this test, I have assumed I'm being asked to analyse all the questions on the supplied date.

## More Time

If I had more time, I would have liked to add more unit tests and Mock the HttpClient so that we could better test the SpecFlow tests.
