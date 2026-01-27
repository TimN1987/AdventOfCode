import Day1 from "./days/day1.js"
import Day2 from "./days/day2.js"

// Day 1
const day1 = new Day1();
let start = process.hrtime.bigint();
day1.moveLift();
let end = process.hrtime.bigint();
console.log(`Day 1 run time = ${(Number(end - start) / 1_000_000).toFixed(4)} ms.`);

// Day 2
const day2 = new Day2();
start = process.hrtime.bigint();
day2.orderStock();
end = process.hrtime.bigint();
console.log(`Day 2 run time = ${(Number(end - start) / 1_000_000).toFixed(4)} ms.`);