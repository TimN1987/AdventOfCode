import fs, { rmSync } from "fs"
import path from "path"

export default class Day11 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day11.txt");
        const data = fs.readFileSync(filePath, "utf-8")
            .trim()
            .split('\r\n')
            .map(line => line.split(' '));
        this.cache = {};
        this.connections = {};
        for (const line of data) {
            const key = line[0].slice(0, -1);
            const value = line.slice(1);
            this.connections[key] = value;
        } 
    }

    printResults() {
        console.log("Day 11:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {
        return this.dfs('you', 'out');
    }

    part2() {
        return this.dfs('svr', 'fft') * this.dfs('fft', 'dac') * this.dfs('dac', 'out');
    }

    dfs(start, target) {
        if (start === target)
            return 1;
        if (start === 'out')
            return 0;
        if (`${start},${target}` in this.cache)
            return this.cache[`${start},${target}`];
        let total = 0;
        for (const c of this.connections[start]) {
            total += this.dfs(c, target);
        }
        this.cache[`${start},${target}`] = total;
        return total;
    }

}