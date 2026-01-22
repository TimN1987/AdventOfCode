class Day2:
    def __init__(self):
        with open("../../Data/2015/day2.txt") as f:
            self.data = f.readlines()
        self.dims = [[int(x) for x in line.split('x')] for line in self.data]
    
    def wrap(self):
        paper, ribbon = 0, 0
        for dims in self.dims:
            dims.sort()
            h, l, w = dims[0], dims[1], dims[2]
            paper += self.surface_area(h, l, w)
            ribbon += self.find_ribbon(h, l, w)
        print(f"The elves require {paper} square feet of paper and {ribbon} feet of ribbon.")

    def surface_area(self, h, l, w):
        area = 2 * (h * l + l * w + h * w)
        extra = h * l
        return area + extra
    
    def find_ribbon(self, h, l, w):
        bow = h * l * w
        ribbon = 2 * (h + l)
        return bow + ribbon