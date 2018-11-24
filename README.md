## Implementation
Algorythm moves from bottom to up because its much faster way of solving this issue
Sample input:
```
1
8 9
1 5 9
4 5 2 3
```
First iteration is takes two last lines and calclutes max sum for each element in the sequence  
>1 has 4 and 5. 5 can't be used because its odd so we take 4. Result => 5  
>5 has 5 and 2. 5 can't be used because its odd so we take 2. Result => 7  
>9 has 2 and 3. 3 can't be used because its odd so we take 2. Result => 11

Now out pyramid looks like this:
```
1
8 9
5 7 11
```
Next iteration:
>8 has 5 (was odd) and 7 (was odd). We take 7 because its bigger than 5. Result => 15  
>9 has 7 (was odd) and 11 (was odd). We take 11 because its bigger than 7. Result => 20 

Now out pyramid looks like this:
```
1
15 20
```
Last iteration:
>1 has 15 (was even) and 20 (was odd). We take 15 because 20 was odd number originally so it does not work for us. Result => 16

`Result 16`

## Note
Rules don't how to handle situation where all parent, left child and right child are all even or odd
I choose to handle this case ending the max path with parent, because we can't continue forward.
For instance if we have pyramid:
```
1
1 1
```
Max path would be 1 because last line does not follow rules