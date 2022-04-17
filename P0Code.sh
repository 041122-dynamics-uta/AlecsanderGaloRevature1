red="\033[31m"
redb="\033[41m"
green="\033[32m"
greenb="\033[42m"
bold="\033[1m"
nc="\033[0m"
echo -e ${bold}Enter your name to begin.${nc}
read name

echo -e ${green}Hi $name, welcome to ${bold}Serverely Limited Calculator™.${nc}
while [ x != q ]
do
echo -e "\n"
echo -e "${green}${bold}What function would you like to perform?${nc}" 
echo -e "     ${green}'a' to add - 's' to substract - 'm' to multiply - 'd' to divide${nc}"
echo -e ${bold}"     'q' to quit${nc}"
read x

if [ $x == a ];
	then echo -e "${bold}Please enter first number${nc}"
	read add1
	echo -e "${bold}Please enter second number${nc}"
	read add2
	add3=$((add1 + add2))
	echo -e "${bold}${greenb}The sum is $add3${nc}"
	fi
if [ $x == s ];
	then echo -e "${bold}Please enter first number${nc}"
        read sub1
        echo -e "${bold}Please enter second number${nc}"
        read sub2
	sub3=$((sub1 - sub2))
	echo -e "${bold}${greenb}The difference is $sub3${nc}"
	fi
if [ $x == m ];
	then echo -e "${bold}Please enter first number${nc}"
        read mult1
        echo -e "${bold}Please enter second number${nc}"
        read mult2
	mult3=$((mult1 * mult2))
	echo -e "${bold}${greenb}The product is $mult3${nc}"
	fi
if [ $x == d ];
	then echo -e "${bold}Please enter first number${nc}"
        read div1
        echo -e "${bold}Please enter second number${nc}"
        read div2
	if [ $div2 == 0 ];
		then echo -e ${red}${bold}DONT DO THAT.${nc}
		echo -e ${bold}It looks like the program has decided to stop interacting with you. Try again later.${nc}
		exit
		fi
	div3=$((div1 / div2))
	mod=$((div1 % div2))
	echo -e "${bold}${greenb}The quotient is $div3${nc}"
	echo -e "${bold}${greenb}The modulus is $mod${nc}"
	fi
if [ $x == q ];
	then exit
	fi 
done

