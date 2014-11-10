```
module Sort where
```

This declares the module.

**Links**
* Loading Modules:  http://learnyouahaskell.com/modules#loading-modules

```
nextBin	:: (Num a, Ord a) => a -> [a] -> [a] -> ([a], [a])
```

This defines the method signature of nextBin. You can break it down as follows:
	nextBin	:: 
		This means the definition relates to nextBin
	(Num a, Ord a)
		This is used to restrict the types to Num and Ord. Num is a number supertype and Ord means it can be compared using < and >.
    a -> [a] -> [a] -> ([a], [a])
    	This is the method signature. It says that the function takes a, [a], [a] and returns ([a], [a]).
    	This is useful because haskell leans heavily on currying functions.
    	See the link for a explaination of currying.	    	

**Links**
* Curried Functions: http://learnyouahaskell.com/higher-order-functions#curried-functions
* Tuples: http://learnyouahaskell.com/starting-out#tuples

```
nextBin _ [] box = (box, [])
```

Haskell uses parameter pattern matching to determine which function it should run. This is how you can achieve function overloading.
You can see that 
	_ is used to say this is a parameter we don't care about.
	[] is used to say when an empty list is passed into the second parameter
This also returns a tuple. A tuple is similar to a c# struct in that it is a way of dealing with multiple pieces of data in a known format in a single structure.

**Links**
* Pattern Matching: http://learnyouahaskell.com/syntax-in-functions#pattern-matching
* Tuples: http://learnyouahaskell.com/starting-out#tuples

```
nextBin size remenants@(item:items) box = 
```

Haskell uses parameter pattern matching to determine which function it should run. This is how you can achieve function overloading.
remenants@(item:items) means when a list is provided put the whole list in remenants, put the first item (the head) in item and the other items (the tail) in items.

**Links**
* Pattern Matching: http://learnyouahaskell.com/syntax-in-functions#pattern-matching
* remenants@(item:items): http://learnyouahaskell.com/syntax-in-functions

```
if (foldl (+) item box) <= size
```

This line uses foldl to sum the elements in the box and then new item to see if the total will fit in the box.
(+) can be used on it's own because the signature (+) :: Num a => a -> a -> a. This means that it's expecting two inputs of a and will provide an output of a. foldl will provide + two parameters that (+) requires so we don't need to specify anything. This is a good example of function currying.

**Links**
* Folds (http://learnyouahaskell.com/higher-order-functions#folds)
* Curried Functions: http://learnyouahaskell.com/higher-order-functions#curried-functions

```
then nextBin size items (item:box)
```

Here we're calling nextBin again with the rest of the items and the item adding to the box.
(item:box) means add the element (item) to the beginning of the list (box).

**Links**
* Recursion (http://learnyouahaskell.com/recursion#hello-recursion) 

```
else (box, remenants)
```

Because we can't fit the next item in we are returning what is in the box and the remaining items.

**Links**
* Tuples (http://learnyouahaskell.com/starting-out#tuples)

```
getBin :: (Num a, Ord a) => a -> [a] -> [[a]]
```

This defines the method signature of getBin. You can break it down as follows:
	getBin	:: 
		This means the definition relates to nextBin
	(Num a, Ord a)
		This is used to restrict the types to Num and Ord. Num is a number supertype and Ord means it can be compared using < and >.
    a -> [a] -> [[a]]
    	This is the method signature. It says that the function takes a, [a] and returns [[a]].
    	This is useful because haskell leans heavily on currying functions.
    	See the link for a explaination of currying.	    	

**Links**
* Curried Functions: http://learnyouahaskell.com/higher-order-functions#curried-functions
* Tuples: http://learnyouahaskell.com/starting-out#tuples

```
getBin _ [] = []
```

Haskell uses parameter pattern matching to determine which function it should run. This is how you can achieve function overloading.
You can see that _ is used to say this is a parameter we don't care about.
[] is used to say when an empty list is passed into the second parameter.
This is so when we are recursively concatonating we have a list at the end of the list to put the elements into.
	ie 4:3:2:1:[] will work but 4:3:2:1 wouldn't.

Links
	Pattern Matching: http://learnyouahaskell.com/syntax-in-functions#pattern-matching

```
getBin bin_size allItems = 
```

Haskell uses parameter pattern matching to determine which function it should run. This is how you can achieve function overloading.

**Links**
* Pattern Matching: http://learnyouahaskell.com/syntax-in-functions#pattern-matching

```
let next = nextBin bin_size	allItems []
```

Here you can see an example of let. This means that first haskell will evaluate the nextBin function call and return the result (a tuple) into next. We can then use next later on.

**Links**
* Let: http://learnyouahaskell.com/syntax-in-functions#let-it-be

```
in (fst next) : getBin bin_size (snd next)
```

This is the part that uses the let.
We concatonate the first element of the tuple with the next box (the elements that wouldn't fit in the box).

**Links**
* List concatonation (http://learnyouahaskell.com/starting-out#an-intro-to-lists)
* Recursion (http://learnyouahaskell.com/recursion#hello-recursion)
