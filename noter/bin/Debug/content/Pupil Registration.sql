-- Registration - Pupil Registration
SELECT
	m.person_id AS [Pupil ID]
,	s.att_session_id AS [Date Time Schedule Id]
,	CASE WHEN m.mark IN ('/','\') THEN 'Yes' ELSE 'No' END AS [Present]
,	CASE WHEN m.mark IN ('/','\') THEN '' ELSE c.external_code END AS [Absent Code]
,	CASE WHEN m.mark IN ('/','\') THEN '' ELSE c.description END AS [Absent Note]
FROM sims.att_mark_normalised m
INNER JOIN sims.att_code c ON m.mark = c.code
INNER JOIN sims.att_week w on m.att_week_id = w.att_week_id
INNER JOIN sims.att_session s on m.att_week_id = s.att_week_id
INNER JOIN sims.sims_event_instance i on m.session_start = i.event_start AND s.event_instance_id = i.event_instance_id
INNER JOIN sims.sims_event_instance tei ON m.session_start >= tei.event_start AND i.event_end <= tei.event_end
INNER JOIN sims.sims_event AS tev ON tei.event_id=tev.event_id AND tev.event_type_id='5'
INNER JOIN sims.sims_event_type AS tet ON tev.event_type_id = tet.event_type_id
INNER JOIN (	SELECT tsh.end_date,tsh.start_date,ts.person_id
				FROM sims.stud_student AS ts
				INNER JOIN sims.stud_school_history AS tsh ON tsh.person_id = ts.person_id
				INNER JOIN sims.sims_via_school_details AS vsd ON vsd.school_id = tsh.school_id AND vsd.status = 'S') 
				endd ON m.person_id=endd.person_id AND (m.session_start <= endd.end_date OR endd.end_date IS NULL) AND m.session_start >= endd.start_date
WHERE m.session_start <= GETDATE()
-- Gets the last 4 years of data. If you need all remove this line. Change '-4' for number of years to go back.
AND m.session_start >= DATEADD(yy, -7, GETDATE())
AND DATEPART(dw, m.session_start) NOT IN (1,7)
ORDER BY m.session_start DESC