# Overview

Kaprekar's constant

## Definition

**6174** is known as Kaprekar's constant after the Indian mathematician D. R. Kaprekar. This number is notable for the following rule:

```text
1. Take any four-digit number, using at least two different digits (leading zeros are allowed).
2. Arrange the digits in descending and then in ascending order to get two four-digit numbers, adding leading zeros if necessary.
3. Subtract the smaller number from the bigger number.
4. Go back to step 2 and repeat.
```

The above process, known as Kaprekar's routine, will always reach its fixed point, **6174**, in at most 7 iterations. Once **6174** is reached, the process will continue yielding 7641 – 1467 = **6174**. For example, choose 1495:

```text
9541 – 1459 = 8082
8820 – 0288 = 8532
8532 – 2358 = **6174**
7641 – 1467 = **6174**
```

The only four-digit numbers for which Kaprekar's routine does not reach **6174** are repdigits such as 1111, which give the result 0000 after a single iteration. All other four-digit numbers eventually reach **6174** if leading zeros are used to keep the number of digits at 4.

[**6174** (number)](https://en.wikipedia.org/wiki/6174_(number))
