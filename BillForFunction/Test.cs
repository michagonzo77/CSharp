  Subscription newPlan = new Subscription(1, 1, 4);

  User[] noUsers = new User[0];

  User[] constantUsers = {
      new User(1, "Employee #1", new DateTime(2018, 11, 4), DateTime.MaxValue, 1),
      new User(2, "Employee #2", new DateTime(2018, 12, 4), DateTime.MaxValue, 1)
  };

  User[] userSignedUp = {
      new User(1, "Employee #1", new DateTime(2018, 11, 4), DateTime.MaxValue, 1),
      new User(2, "Employee #2", new DateTime(2018, 12, 4), DateTime.MaxValue, 1),
      new User(3, "Employee #3", new DateTime(2019, 1, 10), DateTime.MaxValue, 1),
  };

Console.WriteLine(Challenge.BillFor("2019-01", newPlan, userSignedUp));

Console.WriteLine(Challenge.BillFor("2019-01", newPlan, noUsers));


Console.WriteLine(Challenge.BillFor("2019-01", newPlan, constantUsers));


SELECT a1.first_name||' '||a1.last_name AS "first_lawyer",
      a2.first_name||' '||a2.last_name AS "second_lawyer",
      f.title
FROM lawyer a1, lawyer a2, top_team tt, trial f
WHERE tt.lawyer1 = a1.lawyer_id
AND tt.lawyer2 = a2.lawyer_id
AND f.trial_id IN (
    SELECT segun1.trial_id FROM trial_lawyer fa1, trial_lawyer fa2
    WHERE fa1.trial_id = fa2.trial_id
    AND fa1.lawyer_id = a1.lawyer_id
    AND fa2.lawyer_id = a2.lawyer_id
                );



                (
  SELECT primer.lawyer_id, segun.lawyer_id AS coattorney, count(segun.lawyer_id) AS starts
  FROM attorney segun, attorney primer
  WHERE segun.trial_id = primer.trial_id
  AND segun.lawyer_id <> primer.lawyer_id
  GROUP BY primer.lawyer_id, segun.lawyer_id
  order by starts DESC, primer.lawyer_id
  LIMIT 1
)
SELECT a1.first_name||' '||a1.last_name AS "first_lawyer",
      a2.first_name||' '||a2.last_name AS "second_lawyer",
      f.title
FROM lawyer a1, lawyer a2, most_trials tt, trial f
WHERE tt.lawyer1 = a1.lawyer_id
AND tt.lawyer2 = a2.lawyer_id
AND f.trial_id IN (
    SELECT segun1.trial_id FROM attorney segun1, attorney segun2
    WHERE segun1.trial_id = segun2.trial_id
    AND segun1.lawyer_id = a1.lawyer_id
    AND segun2.lawyer_id = a2.lawyer_id
                );