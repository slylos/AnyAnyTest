# AnyAnyTest

It turns out that LINQ performance, while pretty well optimized, can quite easily consume CPU quite easily.  This test app demonstrates how nested Any() queries can make that happen.

The app currently creates 1 million Person instances and searches for a person using a Random number in 3 different threads using Any().  Initially I used BlockingCollection<T> but it turns out it can also introduce high CPU issues.  I went with List<T> instead.
