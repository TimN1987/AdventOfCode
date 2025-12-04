import fs from "fs"
import path from "path"

export default class Day4 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day4.txt");
        const data = fs.readFileSync(filePath, "utf-8");
        this.lines = data.split('\n').map(line => line.trimEnd());
        this.height = this.lines.length;
        this.width = this.lines[0].length;
        this.grid = this.padGrid();
    }

    printResults() {
        console.log("Day 4:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {
        let result = 0;
        for (let i = 1; i < this.height + 1; i++) {
            for (let j = 1; j < this.width + 1; j++) {
                if (this.grid[i][j] === '@' && this.countNeighbours(i, j) < 4) {
                    result++;
                }
            }
        }
        return result;
    }

    part2() {
        let result = 0;
        while (true) {
            let total = 0;
            for (let i = 1; i < this.height + 1; i++) {
                for (let j = 1; j < this.width + 1; j++) {
                    if (this.grid[i][j] === '@' && this.countNeighbours(i, j) < 4) {
                        total++;
                        this.grid[i][j] = '.';
                    }
                }
            }
            result += total;
            if (total === 0)
                break;
        }
        return result;
    }

    padGrid() {
        const array = []
        const emptyLine = Array(this.width + 2).fill('.');
        array.push([...emptyLine]);
        for (const line of this.lines) {
            array.push(("." + line + ".").split(""));
        }
        array.push([...emptyLine]);
        return array;
    }

    countNeighbours(row, col) {
        let total = 0;
        for (let i = -1; i <= 1; i++) {
            for (let j = -1; j <= 1; j++) {
                if (this.grid[row + i][col + j] == '@')
                    total++;
            }
        }
        return total - 1; // Ignore the @ in row + 0, col + 0
    }
}