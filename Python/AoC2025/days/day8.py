import math

class Day8:
    def __init__(self):
        with open("../../Data/2025/day8.txt") as f:
            self.data = [line.rstrip('\n') for line in f]
        self.positions = [[int(x) for x in line.split(',')] for line in self.data]
        self.distances = self.calculate_distances()

    def part_one(self):
        lengths = [len(circuit) for circuit in self.create_circuits()]
        lengths.sort()
        return lengths[-1] * lengths[-2] * lengths[-3]
    
    def part_two(self):
        start, end = self.create_full_circuit()
        x1, x2 = self.positions[start][0], self.positions[end][0]
        return x1 * x2
    
    def euclidean_distance(self, x1, y1, z1, x2, y2, z2):
        return math.sqrt((x1 - x2) ** 2 + (y1 - y2) ** 2 + (z1 - z2) ** 2)
    
    def calculate_distances(self):
        distances = []
        for i in range(len(self.positions) - 1):
            x1, y1, z1 = self.positions[i][0], self.positions[i][1], self.positions[i][2]
            for j in range(i + 1, len(self.positions)):
                x2, y2, z2 = self.positions[j][0], self.positions[j][1], self.positions[j][2]
                distances.append([self.euclidean_distance(x1, y1, z1, x2, y2, z2), i, j])
        distances.sort()
        return distances
    
    def create_circuits(self):
        circuits = [[self.distances[0][1], self.distances[0][2]]]
        for distance in self.distances[1:1000]:
            start, end = distance[1], distance[2]
            connected = {start, end}
            not_connected = []
            for circuit in circuits:
                if (start in circuit) or (end in circuit):
                    connected.update(circuit)
                else:
                    not_connected.append(circuit)
            not_connected.append(list(connected))
            circuits = not_connected
        return circuits
    
    def create_full_circuit(self):
        circuits = [[self.distances[0][1], self.distances[0][2]]]
        for distance in self.distances[1:]:
            start, end = distance[1], distance[2]
            connected = {start, end}
            not_connected = []
            for circuit in circuits:
                if (start in circuit) or (end in circuit):
                    connected.update(circuit)
                else:
                    not_connected.append(circuit)
            if len(not_connected) == 0:
                return start, end
            not_connected.append(list(connected))
            circuits = not_connected
        return -1, -1

    def print_solution(self):
        print("Day 8:")
        print(f"Part 1: {self.part_one()}")
        print(f"Part 2: {self.part_two()}")