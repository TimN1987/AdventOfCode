class Day3:
    def __init__(self):
        with open("../../Data/2015/day3.txt") as f:
            self.data = f.read()
        self.directions = {
            '^': (0, -1),
            'v': (0, 1),
            '>': (1, 0),
            '<': (-1, 0)
        }

    def deliver(self):
        santa_visited = set()
        robo_santa_visited = set()
        position = (0, 0)
        santa_position = (0, 0)
        robo_santa_position = (0, 0)
        santa_move = True
        for d in self.data:
            dx, dy = self.directions[d]
            position = (position[0] + dx, position[1] + dy)
            santa_visited.add(position)
            if santa_move:
                santa_position = (santa_position[0] + dx, santa_position[1] + dy)
                robo_santa_visited.add(santa_position)
                santa_move = not santa_move
            else:
                robo_santa_position = (robo_santa_position[0] + dx, robo_santa_position[1] + dy)
                robo_santa_visited.add(robo_santa_position)
                santa_move = not santa_move
        print(f"Classic santa visited {len(santa_visited)} houses at least once. With robo-Santa helping, Santa visited {len(robo_santa_visited)} houses.")
