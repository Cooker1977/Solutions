module MathMethods

let ( ** ) x y = 
    let rec loop acc counter =
        if counter > 1 then
            loop (acc * x) (counter - 1)
        else
            acc
    match y with
    | 0 -> 1.0
    | _ when y < 0 -> 1.0 / loop x -y
    | _ ->  loop x y