import fs from "fs"
import path from "path"

export default class Day1 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day1.txt");
        const data = fs.readFileSync(filePath, "utf-8");
        this.lines = data.trim().split("\n");
    }

    printResults() {
        console.log("Day 1:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {
        let dial = 50;
        let count = 0;
        const rotations = this.lines.map(this.parseRotation.bind(this));
        for (const rotation of rotations) {
            dial = (dial + rotation) % 100;
            if (dial === 0)
                count++;
        }
        return count;
    }

    part2() {
        let dial = 50;
        let count = 0;
        for (const line of this.lines) {
            const step = line[0] === 'R' ? 1 : -1;
            const distance = parseInt(line.slice(1));
            for (let i = 0; i < distance; i++) {
                dial = (100 + dial + step) % 100;
                if (dial === 0)
                    count++;
            }
        }

        return count;
    }

    parseRotation(rotation) {
        const distance = rotation[0] == 'R' 
            ? parseInt(rotation.slice(1)) 
            : - parseInt(rotation.slice(1));
        return distance;
    }
}