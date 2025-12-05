class Day5:
    def __init__(self):
        with open("../../Data/2025/day5.txt") as f:
            self.data = [line.rstrip('\n') for line in f]
        self.available_ingredients = []
        self.add_available()
        self.fresh_ranges = []
        self.add_fresh_ranges()

    def part_one(self):
        total = 0
        for num in self.available_ingredients:
            for span in self.fresh_ranges:
                if self.check_in_range(span, num):
                    total += 1
                    break
        return total

    def part_two(self):
        total = 0
        i = 0
        while i < len(self.fresh_ranges):
            start, end = self.fresh_ranges[i][0], self.fresh_ranges[i][1]
            i += 1
            while (i < len(self.fresh_ranges)) and (self.fresh_ranges[i][0] <= end):
                end = self.fresh_ranges[i][1] if self.fresh_ranges[i][1] > end else end
                i += 1
            total += end - start
        return total
    
    def add_available(self):
        for line in self.data:
            if '-' in line or line == "":
                continue
            self.available_ingredients.append(int(line))

    def add_fresh_ranges(self):
        for line in self.data:
            if line == "":
                break
            span = line.split('-')
            start, end = int(span[0]), int(span[1])
            self.fresh_ranges.append([start, end + 1])
        self.fresh_ranges = sorted(self.fresh_ranges)

    def check_in_range(self, span, num):
        if num < span[0]:
            return False
        if num >= span[1]:
            return False
        return True

    def print_solution(self):
        print("Day 5:")
        print(f"Part 1: {self.part_one()}")
        print(f"Part 2: {self.part_two()}")