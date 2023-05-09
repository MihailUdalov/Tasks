function isValidSudoku(sudoku) {
    if ((sudoku.length !== 9 && sudoku[0].length !== 9) || sudoku.flat().some(x => x === 0)) {
      return false;
    }
  
    const col = new Set();
    const row = new Set();
    const square = new Set();
  
    let colValue;
    let rowValue;
    let squareValue;
  
    for (let i = 0; i < 9; i++) {
      col.clear();
      row.clear();
      square.clear();

      for (let j = 0; j < 9; j++) {

        colValue = sudoku[i][j];
        rowValue = sudoku[j][i];
        squareValue = sudoku[3 * Math.floor(i / 3) + Math.floor(j / 3)][3 * (i % 3) + (j % 3)];

        if (col.has(colValue)) 
            return false;
        col.add(colValue);

        if (row.has(rowValue)) 
            return false;
        row.add(rowValue);

        if (square.has(squareValue)) 
            return false;
        square.add(squareValue);
      }
    }
  
    return true;
  }
  
  const sudoku = [
    [4, 9, 2, 7, 5, 3, 8, 1, 6],
    [3, 5, 8, 6, 9, 1, 7, 2, 4],
    [6, 7, 1, 2, 8, 4, 5, 3, 9],
    [8, 6, 3, 5, 7, 9, 1, 4, 2],
    [2, 1, 7, 3, 4, 8, 6, 9, 5],
    [5, 4, 9, 1, 2, 6, 3, 7, 8],
    [1, 2, 4, 8, 3, 5, 9, 6, 7],
    [9, 3, 6, 4, 1, 7, 2, 5, 8],
    [7, 8, 5, 9, 6, 2, 4, 6, 3] 
  ];
  
  console.log("Your answer:",isValidSudoku(sudoku));