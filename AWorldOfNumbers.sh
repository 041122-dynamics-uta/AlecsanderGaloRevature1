#!bin/bash

read input1
read input2

echo $(expr $input1 + $input2)
echo $(expr $input1 - $input2)
echo $(expr $((input1 * input2)))
echo $(expr $input1 / $input2)
