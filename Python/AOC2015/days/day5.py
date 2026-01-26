class Day5:
    def __init__(self):
        with open("../../Data/2015/day5.txt") as f:
            self.data = f.readlines()

    def check_niceness(self):
        count1, count2 = 0, 0
        for d in self.data:
            if self.is_nice(d):
                count1 += 1
            if self.is_new_nice(d):
                count2 += 1
        print(f"There are {count1} nice strings and {count2} new nice strings.")

    def is_nice(self, input):
        has_double = False
        vowel_count = 0
        invalid = set(['ab', 'cd', 'pq', 'xy'])
        vowels = set(['a', 'e', 'i', 'o', 'u'])
        if (input[0] in vowels):
            vowel_count += 1
        for i in range(1, len(input)):
            if input[i] in vowels:
                vowel_count += 1
            if input[(i - 1) : (i + 1)] in invalid:
                return False
            if not has_double and input[i - 1] == input[i]:
                has_double = True
        return has_double and vowel_count >= 3
    
    def is_new_nice(self, input):
        has_double = False
        doubles = {}
        has_repeat = False
        doubles[input[:2]] = 1
        for i in range(2, len(input)):
            if has_repeat and has_double:
                return True
            if not has_repeat and input[i] == input[i - 2]:
                has_repeat = True
            if not has_double:
                pair = input[i - 1 : i + 1]
                if pair in doubles and i - doubles[pair] > 1:
                    has_double = True
                else:
                    doubles[pair] = i
        return has_repeat and has_double
            