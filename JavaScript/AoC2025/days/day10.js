import fs from "fs";
import path from "path";
import { init } from "z3-solver";

const { Context } = await init();
const Z3 = Context();
const { Int, Optimize } = Z3;

export default class Day10 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day10.txt");
        const data = fs.readFileSync(filePath, "utf-8");
        this.machines = data
            .split("\n")
            .map(line => line.trim())
            .filter(line => line.length > 0)
            .map(line => this.parseLine(line));
    }

    parseLine(line) {
        const parts = line.split(" ");
        const lights = parts[0].slice(1, -1).split("").map(c => c === "#" ? 1 : 0);
        const buttons = parts.slice(1, -1).map(b => b.slice(1, -1).split(",").map(Number));
        const joltage = parts[parts.length - 1].slice(1, -1).split(",").map(Number);
        return [lights, buttons, joltage];
    }

    part1() {
        let total = 0;
        for (const [lights, buttons] of this.machines) {
            const n = buttons.length;
            let min = Infinity;
            for (let i = 1; i < (1 << n); i++) {
                const combo = [];
                for (let j = 0; j < n; j++) if ((i >> j) & 1) combo.push(buttons[j]);
                if (this.matchLights(combo, lights)) min = Math.min(min, combo.length);
            }
            total += min;
        }
        return total;
    }

    matchLights(combo, lights) {
        const pattern = Array(lights.length).fill(0);
        combo.forEach(btn => btn.forEach(b => pattern[b] = 1 - pattern[b]));
        return pattern.every((val, i) => val === lights[i]);
    }

    async part2() {
        let total = 0;
        for (const [_, buttons, joltage] of this.machines) {
            total += await this.solveWithZ3(joltage, buttons);
        }
        return total;
    }

    async solveWithZ3(target, buttons) {
        const numButtons = buttons.length;
        const numLights = target.length;

        const x = Array.from({ length: numButtons }, (_, i) => Int.const(`x_${i}`));

        const opt = new Optimize();

        for (let light = 0; light < numLights; light++) {
            const affecting = x.filter((_, j) => buttons[j].includes(light));
            const sum = affecting.reduce((acc, xi) => acc.add(xi), Int.val(0));
            opt.add(sum.eq(Int.val(target[light])));
        }

        for (let xi of x) opt.add(xi.ge(Int.val(0)));

        let totalExpr = x[0];
        for (let i = 1; i < x.length; i++) totalExpr = totalExpr.add(x[i]);
        opt.minimize(totalExpr);

        const status = await opt.check();
        if (status !== "sat") throw new Error("No solution found");

        const model = opt.model();
        let sumPresses = 0n;
        for (let xi of x) {
            const val = model.eval(xi).toString();
            sumPresses += BigInt(val);
        }

        return Number(sumPresses);
    }

    async printResults() {
        console.log("Day 10:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${await this.part2()}`);
    }
}
