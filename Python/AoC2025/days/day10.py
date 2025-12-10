from itertools import product
import pulp
import numpy as np

class Day10:
    def __init__(self):
        with open("../../Data/2025/day10.txt") as f:
            self.data = [[x for x in line.rstrip("\n").split(" ")] for line in f]
        self.machines = [self.parse_line(machine) for machine in self.data]
        print(len(self.machines))

    def part_one(self):
        total = 0
        for machine in self.machines:
            total += self.count_steps(machine)
        return total

    def part_two(self):
        total = 0
        for machine in self.machines:
            total += self.create_joltages(machine)
        return total

    def parse_line(self, machine):
        lights = [x for x in machine[0][1:-1]]
        buttons = [[int(num) for num in button[1:-1].split(",")] for button in machine[1:-1]]
        joltages = [int(x) for x in machine[-1][1:-1].split(",")]
        return [lights, buttons, joltages]
    
    def count_steps(self, machine):
        lights, buttons, joltages = machine
        n = len(buttons)
        min_combo = 100000000
        for i in range(0, 2**n):
            combo = [buttons[j] for j in range(n) if (i >> j) & 1]
            if self.match_lights(lights, combo):
                    min_combo = min(len(combo), min_combo)
        return min_combo
    
    def create_joltages(self, machine):
        _, buttons, joltages = machine
        presses, _ = self.solve_joltages(buttons, joltages)
        return presses

    def solve_joltages(self, buttons, joltages):
        n_buttons = len(buttons)
        n_joltages = len(joltages)
        A = np.zeros((n_joltages, n_buttons), dtype=int)
        for j, btn in enumerate(buttons):
            for i in btn:
                A[i, j] = 1

        prob = pulp.LpProblem("MinButtonPresses", pulp.LpMinimize)
        c_vars = [pulp.LpVariable(f"c{i}", lowBound=0, cat='Integer') for i in range(n_buttons)]

        prob += pulp.lpSum(c_vars)

        for i in range(n_joltages):
            prob += pulp.lpSum(A[i, j]*c_vars[j] for j in range(n_buttons)) == joltages[i]

        prob.solve(pulp.PULP_CBC_CMD(msg=False))

        solution = [int(var.value()) for var in c_vars]
        total_presses = sum(solution)
        return total_presses, solution

    def count_joltages(self, machine):
        [lights, buttons, joltages] = machine
        maxValues = []
        for b in buttons:
            maxValues.append(max([joltages[i] for i in b]))   
        ranges = [range(m+1) for m in maxValues]
        min_count = 10000000000
        for combo_counts in product(*ranges):
            if self.match_joltages(lights, combo_counts, buttons):
                min_count = min(sum(combo_counts), min_count)

    def match_lights(self, lights, combo):
        length = len(lights)
        pattern = [False] * length
        for button in combo:
            for b in button:
                pattern[b] = not pattern[b]
        for i in range(length):
            if (lights[i] == '#') and (not pattern[i]):
                return False
            elif (lights[i] == '.') and pattern[i]:
                return False
        return True
    
    def match_joltages(self, joltages, combos, buttons):
        length = len(joltages)
        pattern = [0] * length
        for i in range(len(combos)):
            for b in buttons[i]:
                pattern[b] += combos[i]
        for i in range(length):
            if pattern[i] != joltages[i]:
                return False
        return True

    def print_solution(self):
        print("Day 10:")
        print(f"Part 1: {self.part_one()}")
        print(f"Part 2: {self.part_two()}")