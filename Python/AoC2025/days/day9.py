class Day9:
    def __init__(self):
        with open("../../Data/2025/day9.txt") as f:
            self.positions = [[int(x) for x in line.rstrip("\n").split(",")] for line in f]

        self.x_coords = sorted({x for x, y in self.positions})
        self.y_coords = sorted({y for x, y in self.positions})
        self.x_map = {x: i for i, x in enumerate(self.x_coords)}
        self.y_map = {y: i for i, y in enumerate(self.y_coords)}

        self.compressed = [(self.x_map[x], self.y_map[y]) for x, y in self.positions]

        self.rectangles = self.find_sorted_rectangles()
        self.edge = self.scan_edges()

    def part_one(self):
        return self.rectangles[0][0]

    def part_two(self):
        for area, i, j in self.rectangles:
            a = self.compressed[i]
            b = self.compressed[j]
            if self.check_rectangle(a, b):
                return area
        return 0

    def find_area(self, a, b):
        return (abs(a[0] - b[0]) + 1) * (abs(a[1] - b[1]) + 1)

    def find_sorted_rectangles(self):
        rectangles = []
        n = len(self.positions)
        for i in range(n - 1):
            for j in range(i + 1, n):
                area = self.find_area(self.positions[i], self.positions[j])
                rectangles.append([area, i, j])
        rectangles.sort(key=lambda x: x[0], reverse=True)
        return rectangles

    def scan_edges(self):
        edge = set()
        coords = self.compressed.copy()
        prev = coords[0]
        coords.append(prev)
        for curr in coords[1:]:
            x1, y1 = prev
            x2, y2 = curr
            if x1 == x2:
                for y in range(min(y1, y2), max(y1, y2) + 1):
                    edge.add((x1, y))
            elif y1 == y2:
                for x in range(min(x1, x2), max(x1, x2) + 1):
                    edge.add((x, y1))
            prev = curr
        return edge

    def check_rectangle(self, a, b):
        x1, y1 = a
        x2, y2 = b
        minX, maxX = min(x1, x2), max(x1, x2)
        minY, maxY = min(y1, y2), max(y1, y2)

        for x in range(minX + 1, maxX):
            if (x, minY + 1) in self.edge or (x, maxY - 1) in self.edge:
                return False
        for y in range(minY + 1, maxY):
            if (minX + 1, y) in self.edge or (maxX - 1, y) in self.edge:
                return False
        return True

    def print_solution(self):
        print("Day 9:")
        print(f"Part 1: {self.part_one()}")
        print(f"Part 2: {self.part_two()}")

