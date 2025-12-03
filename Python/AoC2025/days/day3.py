class Day3:
    def __init__(self):
        with open("../../Data/2025/day3.txt") as f:
            self.data = f.readlines()

    def part_one(self):
        return self.sum_batteries(2)
    
    def part_two(self):
        return self.sum_batteries(12)

    def sum_batteries(self, num_size):
        total = 0
        for line in self.data:
            total += self.find_num(line, num_size)
        return total

    def find_next_digit(self, position, line, prev_index, num_size):
        i = prev_index + 1
        next_index = i
        max_digit = '0'
        while i < len(line) - num_size + position:
            if line[i] > max_digit:
                max_digit = line[i]
                next_index = i
            i += 1
        return max_digit, next_index
    
    def find_num(self, line, num_size):
        result = ''
        index = -1
        for i in range(num_size):
            next_digit, index = self.find_next_digit(i, line, index, num_size)
            result += next_digit
        return int(result)
    
    def print_solution(self):
        print("Day 3:")
        print(f"Part 1: {self.part_one()}")
        print(f"Part 2: {self.part_two()}")