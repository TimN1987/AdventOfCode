import fs, { rmSync } from "fs"
import path from "path"

export default class Day12 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day12.txt");
        this.data = fs.readFileSync(filePath, "utf-8").split('\n').map(line => line.trim());
    } 

    printResults() {
        console.log("Day 12:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {
        const sizes = {};
        let num = 0;
        let present = 0;
        let region = 0;
        let actualSize = 0;
        let total = 0;
        for (const line of this.data) {
            if (line === '') {
                sizes[num] = present;
                present = 0;
            } else if (line.length === 2) {
                num = parseInt(line[0]);
            } else if (line.includes('#')) {
                for (const c of line) {
                    if (c === '#')
                        present++;
                }
            } else {
                const info = line.split(' ');
                region = parseInt(info[0].slice(0, 2)) * parseInt(info[0].slice(3, 5));

                for (let i = 1; i < info.length; i++) {
                    actualSize += sizes[i - 1] * parseInt(info[i]);
                }

                if (actualSize <= region)
                    total++;

                actualSize = 0;
            }
        }
        return total;
    }

    part2() {
        return "Marry Christmas!";
    }

}