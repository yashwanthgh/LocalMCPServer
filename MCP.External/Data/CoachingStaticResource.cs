namespace MCP.External.Data
{
    internal static class CoachingStaticResource
    {
        internal static readonly string CoachingSessions =
            @"
                {
                  ""coachingSessions"": [
                    {
                      ""CoachingSessionId"": 1,
                      ""Coach"": ""Jennifer Ferrari"",
                      ""Driver"": ""Joseph Robinson"",
                      ""CoachingDate"": ""2026-03-17"",
                      ""CoachingSessionNotes"": ""Driver had two distraction-related events in the prior week. Reviewed camera footage showing phone use while driving. Driver was receptive and acknowledged the risk."",
                      ""CoachingSessionActionPlan"": ""Place phone in Do Not Disturb mode before every shift. Coach to review telematics again by 3/27. Note: Driver received Event Recognition on 3/23 for safe driving on event AATKM91891 — improvement noted.""
                    },
                    {
                      ""CoachingSessionId"": 2,
                      ""Coach"": ""Melissa Noe"",
                      ""Driver"": ""Gerald Thomas"",
                      ""CoachingDate"": ""2026-03-10"",
                      ""CoachingSessionNotes"": ""Reviewed three prior events with scores above 4 from late February. Driver showed strong awareness during coaching ride-along. Discussed defensive driving techniques on highway segments."",
                      ""CoachingSessionActionPlan"": ""Increase following distance to 4 seconds minimum. Monitor score weekly. Note: Driver received Event Recognition on 3/25 for event AATKZ38150 — sustained improvement confirmed.""
                    },
                    {
                      ""CoachingSessionId"": 3,
                      ""Coach"": ""Melissa Noe"",
                      ""Driver"": ""Nathan McCrory"",
                      ""CoachingDate"": ""2026-03-05"",
                      ""CoachingSessionNotes"": ""Previous month showed braking score improvements but occasional harsh cornering. Reviewed route map and identified two high-risk turns near the depot."",
                      ""CoachingSessionActionPlan"": ""Slow to 15 mph before marked turns. Share route feedback with dispatch. Note: Driver received Event Recognition on 3/25 for event AATKM74451.""
                    },
                    {
                      ""CoachingSessionId"": 4,
                      ""Coach"": ""Michael Session II"",
                      ""Driver"": ""Brent Roach"",
                      ""CoachingDate"": ""2026-03-12"",
                      ""CoachingSessionNotes"": ""Driver scored 0 on last three scored events — consistent improvement over 60 days. Coaching session focused on maintaining momentum and peer mentoring."",
                      ""CoachingSessionActionPlan"": ""Nominate driver for mentor role in Q2. Continue zero-incident streak. Note: Received Event Recognition on 3/24 for event AATHC74669.""
                    },
                    {
                      ""CoachingSessionId"": 5,
                      ""Coach"": ""Michael Session II"",
                      ""Driver"": ""Gage Carter"",
                      ""CoachingDate"": ""2026-03-08"",
                      ""CoachingSessionNotes"": ""Discussed prior cornering events near STC Chelsea facility. Driver explained road conditions at the problematic turn. Map review conducted."",
                      ""CoachingSessionActionPlan"": ""Report maintenance issue on Elm St curve to facilities. Adjust personal speed threshold to 20 mph on that segment. Note: Received Event Recognition on 3/24 for event AATJQ43268.""
                    },
                    {
                      ""CoachingSessionId"": 6,
                      ""Coach"": ""Jennifer Ferrari"",
                      ""Driver"": ""Vicente Trevino"",
                      ""CoachingDate"": ""2026-03-14"",
                      ""CoachingSessionNotes"": ""Two events in the same week for the PA054 route — both related to following distance. Driver cited traffic congestion as a factor."",
                      ""CoachingSessionActionPlan"": ""Depart 15 minutes earlier on heavy traffic days. Use alternate Route 9 during peak hours. Note: Driver received two Event Recognitions on 3/23 for events AATKM77939 and AATKK67779.""
                    },
                    {
                      ""CoachingSessionId"": 7,
                      ""Coach"": ""Brian Fischer"",
                      ""Driver"": ""Joshua Graef"",
                      ""CoachingDate"": ""2026-03-11"",
                      ""CoachingSessionNotes"": ""Driver's scores improved steadily from 8 to 2 over the past 6 weeks. Session focused on recognizing the improvement and discussing next-level defensive driving."",
                      ""CoachingSessionActionPlan"": ""Enroll in advanced defensive driving webinar by April. Note: Driver received Event Recognition on 3/23 for event AATKM93793.""
                    },
                    {
                      ""CoachingSessionId"": 8,
                      ""Coach"": ""Melissa Noe"",
                      ""Driver"": ""Triciona Hunter"",
                      ""CoachingDate"": ""2026-03-13"",
                      ""CoachingSessionNotes"": ""Event AATKJ04618 on 3/20 showed Smoking and Steering Wheel Control behaviors with a score of 2. Prior coaching addressed distraction. Session reviewed footage and emphasized hands-on-wheel policy."",
                      ""CoachingSessionActionPlan"": ""No smoking while vehicle is in motion. Sign the distraction-free driving commitment form. Follow-up scheduled for 3/31.""
                    },
                    {
                      ""CoachingSessionId"": 9,
                      ""Coach"": ""Kevin Smith"",
                      ""Driver"": ""Clayton Rogers"",
                      ""CoachingDate"": ""2026-03-06"",
                      ""CoachingSessionNotes"": ""Event AATKN79372 on 3/20 showed Lens Obstruction behavior. Driver acknowledged an object was placed near the camera by accident. Incident reviewed."",
                      ""CoachingSessionActionPlan"": ""Perform daily camera check before departure. Remove all items from dash that could obstruct the lens.""
                    },
                    {
                      ""CoachingSessionId"": 10,
                      ""Coach"": ""John Miller"",
                      ""Driver"": ""John Heddinger"",
                      ""CoachingDate"": ""2026-03-03"",
                      ""CoachingSessionNotes"": ""Event AATKL68809 on 3/20 scored 6 for Other Distraction during Rough/Uneven Surface trigger. Driver was navigating a detour when the event occurred."",
                      ""CoachingSessionActionPlan"": ""Pre-check route for roadwork or closures daily. Keep both hands on wheel during all surface transitions.""
                    },
                    {
                      ""CoachingSessionId"": 11,
                      ""Coach"": ""Ryan Malone"",
                      ""Driver"": ""Benjamin Henderson"",
                      ""CoachingDate"": ""2026-02-27"",
                      ""CoachingSessionNotes"": ""Event AATKL86650 on 3/20 scored 6 for Red Light behavior. Previous month had no events. Discussed signal anticipation and intersection scanning."",
                      ""CoachingSessionActionPlan"": ""Complete online intersection safety module by March 15. Coach to review event footage together within the week.""
                    },
                    {
                      ""CoachingSessionId"": 12,
                      ""Coach"": ""George Black"",
                      ""Driver"": ""Jeremy Ritter"",
                      ""CoachingDate"": ""2026-02-20"",
                      ""CoachingSessionNotes"": ""Event AATKL94443 on 3/20 showed Backing behavior on a Rough/Uneven Surface trigger. TCC Omaha loading dock area identified as a recurring blind-spot concern."",
                      ""CoachingSessionActionPlan"": ""Always use a spotter when backing at the Omaha dock. Install mirror request submitted. Score 2 — continue improvement.""
                    },
                    {
                      ""CoachingSessionId"": 13,
                      ""Coach"": ""Timothy Williams"",
                      ""Driver"": ""Aaron Meyer"",
                      ""CoachingDate"": ""2026-02-18"",
                      ""CoachingSessionNotes"": ""Event AATKM42274 on 3/20 was an Accelerating trigger with no recorded behaviors and score of 0 — resolved quickly. Session was proactive given prior pattern."",
                      ""CoachingSessionActionPlan"": ""Maintain gradual acceleration protocol. Driver performing well — eligible for recognition nomination in Q2.""
                    },
                    {
                      ""CoachingSessionId"": 14,
                      ""Coach"": ""Monica Scott"",
                      ""Driver"": ""Jason Campbell"",
                      ""CoachingDate"": ""2026-02-14"",
                      ""CoachingSessionNotes"": ""Event AATKM68412 on 3/20 was a Cornering trigger with score 0, status Resolved. Driver self-corrected before coach review. Positive reinforcement session."",
                      ""CoachingSessionActionPlan"": ""Continue self-monitoring. Add driver to the peer safety ambassador program.""
                    },
                    {
                      ""CoachingSessionId"": 15,
                      ""Coach"": ""Caleb Benson"",
                      ""Driver"": ""Anthony Carroll"",
                      ""CoachingDate"": ""2026-02-10"",
                      ""CoachingSessionNotes"": ""Event AATKH26874 in ANS Charlotte involved hard braking near a school zone. Driver explained a child ran into the road. Reviewed footage — reaction was appropriate."",
                      ""CoachingSessionActionPlan"": ""Incident logged as unavoidable. Driver to present safety scenario at next team meeting.""
                    },
                    {
                      ""CoachingSessionId"": 16,
                      ""Coach"": ""Mitchell LaBouef"",
                      ""Driver"": ""Neil Lalone"",
                      ""CoachingDate"": ""2026-02-06"",
                      ""CoachingSessionNotes"": ""Event AATKU20974 in ECC Elkhart showed hard braking score. Driver acknowledged fatigue as a contributing factor during afternoon run."",
                      ""CoachingSessionActionPlan"": ""Mandatory rest break after 4 hours of driving. Fatigue management policy signed. Re-evaluate in 30 days.""
                    },
                    {
                      ""CoachingSessionId"": 17,
                      ""Coach"": ""Cody Miles"",
                      ""Driver"": ""Terry Bryant"",
                      ""CoachingDate"": ""2026-01-30"",
                      ""CoachingSessionNotes"": ""Event AATKR36998 in STC Woodlawn involved following distance. Driver has been with the fleet for 8 years with minimal incidents — this was out of pattern."",
                      ""CoachingSessionActionPlan"": ""Review updated following distance policy (4-second rule). Self-monitor for 30 days.""
                    },
                    {
                      ""CoachingSessionId"": 18,
                      ""Coach"": ""Joseph Murphy"",
                      ""Driver"": ""Khalid Williams"",
                      ""CoachingDate"": ""2026-01-24"",
                      ""CoachingSessionNotes"": ""Event AATKR52283 in UTQ 113 NJFR showed distraction behavior. Driver was checking a paper manifest when the event occurred."",
                      ""CoachingSessionActionPlan"": ""Switch to digital manifest on tablet. No paper documents on the dash. Sign off on distraction-free policy.""
                    },
                    {
                      ""CoachingSessionId"": 19,
                      ""Coach"": ""Michael Bovia"",
                      ""Driver"": ""Gary McKinney"",
                      ""CoachingDate"": ""2026-01-17"",
                      ""CoachingSessionNotes"": ""Event AATKQ86234 in TCC Omaha — second event in 30 days for the same driver and similar behavior. Reviewed pattern over past quarter."",
                      ""CoachingSessionActionPlan"": ""Enroll in mandatory safe driving refresher course. Bi-weekly check-ins through February.""
                    },
                    {
                      ""CoachingSessionId"": 20,
                      ""Coach"": ""Jeff Griwatsch"",
                      ""Driver"": ""Jesse Ezell"",
                      ""CoachingDate"": ""2026-01-10"",
                      ""CoachingSessionNotes"": ""Event AATKT07006 in PTI RALENCGFBR showed sudden cornering. Driver navigating an unfamiliar route during a fill-in shift."",
                      ""CoachingSessionActionPlan"": ""Brief drivers on new routes before fill-in shifts. Require route walkthrough for unfamiliar assignments.""
                    },
                    {
                      ""CoachingSessionId"": 21,
                      ""Coach"": ""Melissa Noe"",
                      ""Driver"": ""Jacob Banks"",
                      ""CoachingDate"": ""2026-01-06"",
                      ""CoachingSessionNotes"": ""Event AATKS99951 in ANS Georgia FOB showed distraction behavior. Camera review showed driver looking at side mirror for an extended period in traffic."",
                      ""CoachingSessionActionPlan"": ""Mirror adjustment routine before every shift. Reduce mirror-check duration to < 2 seconds while moving.""
                    },
                    {
                      ""CoachingSessionId"": 22,
                      ""Coach"": ""Michael Whiting"",
                      ""Driver"": ""Jessica Evans"",
                      ""CoachingDate"": ""2025-12-19"",
                      ""CoachingSessionNotes"": ""Event AATKT18468 in UTQ 160 VACE. Driver is high performer with strong scores but one anomalous harsh braking event near a construction zone."",
                      ""CoachingSessionActionPlan"": ""Flag construction zones in route planner. Driver to share experience at next team safety meeting.""
                    },
                    {
                      ""CoachingSessionId"": 23,
                      ""Coach"": ""Kyle Baker"",
                      ""Driver"": ""Melvin Harris"",
                      ""CoachingDate"": ""2025-12-10"",
                      ""CoachingSessionNotes"": ""Event AATKS75971 in LCS Rocky Mount — backing behavior in the loading area. Multiple vehicles in tight space. Loading dock layout discussed."",
                      ""CoachingSessionActionPlan"": ""Request loading dock reconfiguration from facilities. Use mandatory spotter for all reverse maneuvers.""
                    },
                    {
                      ""CoachingSessionId"": 24,
                      ""Coach"": ""Ryan Malone"",
                      ""Driver"": ""Brandon Head"",
                      ""CoachingDate"": ""2025-11-21"",
                      ""CoachingSessionNotes"": ""Event AATKS92488 in PTI ATLAGAGFBR — Cornering trigger. Driver's route includes several sharp turns near the Atlanta distribution hub."",
                      ""CoachingSessionActionPlan"": ""Reduce speed to 10 mph on identified turns. Submit route review request for safer alternative.""
                    },
                    {
                      ""CoachingSessionId"": 25,
                      ""Coach"": ""George Black"",
                      ""Driver"": ""Alvin Lassiter"",
                      ""CoachingDate"": ""2025-11-07"",
                      ""CoachingSessionNotes"": ""Event AATKZ69364 in ANS Downtown Atlanta. Driver had a near-miss backing into a parking structure. No injury or vehicle damage. High-stress area."",
                      ""CoachingSessionActionPlan"": ""Avoid parking structures where possible. If required, request a spotter. Incident report filed.""
                    },
                    {
                      ""CoachingSessionId"": 26,
                      ""Coach"": ""Jennifer Ferrari"",
                      ""Driver"": ""Nathan Gay"",
                      ""CoachingDate"": ""2025-10-30"",
                      ""CoachingSessionNotes"": ""Event AATKY96156 in ANS Georgia FOB — scored 4 for Backing behavior. Driver had previously completed a backing safety course."",
                      ""CoachingSessionActionPlan"": ""Review backing procedures from previous course. Report any obstacles in the delivery area to the fleet coordinator.""
                    },
                    {
                      ""CoachingSessionId"": 27,
                      ""Coach"": ""Caleb Benson"",
                      ""Driver"": ""Jose Del Cid"",
                      ""CoachingDate"": ""2025-10-14"",
                      ""CoachingSessionNotes"": ""Event AATLA69787 in ANS Raleigh — distraction behavior on highway segment. Driver reported GPS recalculation as distraction trigger."",
                      ""CoachingSessionActionPlan"": ""Mount GPS at eye-level. Pre-program route before starting vehicle. No route changes while in motion.""
                    },
                    {
                      ""CoachingSessionId"": 28,
                      ""Coach"": ""Monica Scott"",
                      ""Driver"": ""Orlando Scott"",
                      ""CoachingDate"": ""2025-09-25"",
                      ""CoachingSessionNotes"": ""Event AATKZ58016 in UTQ 301 ARBR Arkansas — Accelerating trigger with Follow Distance behavior. Driver recently transferred to the Arkansas route."",
                      ""CoachingSessionActionPlan"": ""Complete 30-day supervised period on new route. Pair with experienced driver for first two weeks.""
                    },
                    {
                      ""CoachingSessionId"": 29,
                      ""Coach"": ""Glen Wieck"",
                      ""Driver"": ""Bridgette Ernst"",
                      ""CoachingDate"": ""2025-09-11"",
                      ""CoachingSessionNotes"": ""Event AATLA45097 in ECC Lucedale — scored 6 for Cornering behavior. Driver's route includes a sharp S-curve on Old Highway 98. Discussed approach speed."",
                      ""CoachingSessionActionPlan"": ""Reduce speed to 15 mph before the S-curve. Telematics alert threshold set. Re-review in 60 days.""
                    },
                    {
                      ""CoachingSessionId"": 30,
                      ""Coach"": ""Michael Session II"",
                      ""Driver"": ""Giovanni Eguiguren"",
                      ""CoachingDate"": ""2025-08-28"",
                      ""CoachingSessionNotes"": ""Event AATKT19106 in PTI SLCPUTGFBR — Following Distance trigger on the Salt Lake route. Driver on a long-haul day."",
                      ""CoachingSessionActionPlan"": ""Schedule a mid-shift break on routes exceeding 5 hours. Follow-up in 45 days.""
                    },
                    {
                      ""CoachingSessionId"": 31,
                      ""Coach"": ""Melissa Noe"",
                      ""Driver"": ""Corey Rainford"",
                      ""CoachingDate"": ""2025-08-14"",
                      ""CoachingSessionNotes"": ""Recognition event AATDL74463 (Feb 2026) traces back to consistent improvement following this coaching session. Driver overcame a pattern of late braking near UTQ 171 GACE Central."",
                      ""CoachingSessionActionPlan"": ""Weekly score review with manager. Gradual improvement plan over 6 months.""
                    },
                    {
                      ""CoachingSessionId"": 32,
                      ""Coach"": ""Kevin Smith"",
                      ""Driver"": ""Jacob Ellison"",
                      ""CoachingDate"": ""2025-07-31"",
                      ""CoachingSessionNotes"": ""Driver in BCC Piedmont SC had two back-to-back events in July 2025 with Backing and Cornering behaviors. Seat adjustment and mirror calibration reviewed."",
                      ""CoachingSessionActionPlan"": ""Bi-weekly vehicle inspection checklist. Escalate if more than 1 scored event per month.""
                    },
                    {
                      ""CoachingSessionId"": 33,
                      ""Coach"": ""Timothy Williams"",
                      ""Driver"": ""August Baldridge"",
                      ""CoachingDate"": ""2025-07-10"",
                      ""CoachingSessionNotes"": ""Driver in PTI SEATWACORE — repeated distraction events in June-July 2025. Session focused on the cost of distracted driving and reviewed real-world case studies."",
                      ""CoachingSessionActionPlan"": ""Complete distracted driving online course. Zero tolerance policy acknowledged in writing.""
                    },
                    {
                      ""CoachingSessionId"": 34,
                      ""Coach"": ""Brian Fischer"",
                      ""Driver"": ""Matthew Jennings"",
                      ""CoachingDate"": ""2025-06-20"",
                      ""CoachingSessionNotes"": ""Event from February 2026 recognition (AATEC60643) traces to a habit developed in mid-2025. Driver had a strong Q3 2025 after coaching intervention."",
                      ""CoachingSessionActionPlan"": ""Use daily self-checklist before departing. Month-over-month score target: reduce by 2 points.""
                    },
                    {
                      ""CoachingSessionId"": 35,
                      ""Coach"": ""Mitchell LaBouef"",
                      ""Driver"": ""Derek Dydyk"",
                      ""CoachingDate"": ""2025-06-05"",
                      ""CoachingSessionNotes"": ""Event recognition AASWP80591 (Jan 2026) reflects 6-month improvement journey started here. PTN Professional Teleconcepts route had a known rough stretch causing triggering events."",
                      ""CoachingSessionActionPlan"": ""Request road condition report. Reduce speed by 10 mph on flagged segments.""
                    },
                    {
                      ""CoachingSessionId"": 36,
                      ""Coach"": ""Ryan Malone"",
                      ""Driver"": ""Adrian Bacallao"",
                      ""CoachingDate"": ""2025-05-22"",
                      ""CoachingSessionNotes"": ""Driver in PTI CHARNCGFBR had multiple cornering events in spring 2025. Coaching revealed driver was unfamiliar with route terrain near the Charlotte foothills."",
                      ""CoachingSessionActionPlan"": ""Complete terrain familiarization training. Review event AASXF41019 outcome — recognition issued Jan 2026 confirms full improvement.""
                    },
                    {
                      ""CoachingSessionId"": 37,
                      ""Coach"": ""Joseph Murphy"",
                      ""Driver"": ""Humberto Cerano"",
                      ""CoachingDate"": ""2025-05-08"",
                      ""CoachingSessionNotes"": ""Driver in VCI VC020 Upland Dry had five events in Q1 2025, mostly braking and following distance. High-volume delivery route with frequent stops."",
                      ""CoachingSessionActionPlan"": ""Increase stopping distance by 20%. Request lighter load schedule for first 3 months of year.""
                    },
                    {
                      ""CoachingSessionId"": 38,
                      ""Coach"": ""Cody Miles"",
                      ""Driver"": ""Kemdrick Beadles"",
                      ""CoachingDate"": ""2025-04-17"",
                      ""CoachingSessionNotes"": ""Driver in UTQ 176 GALP Georgia Large Projects — multiple Hard Braking events in Q1 2025. Improvement target set, and driver achieved recognition by Jan 2026 (event AASXF20943)."",
                      ""CoachingSessionActionPlan"": ""Bimonthly score reviews with fleet manager. Gradual reduction target: halve events per month within 6 months.""
                    },
                    {
                      ""CoachingSessionId"": 39,
                      ""Coach"": ""Jeff Griwatsch"",
                      ""Driver"": ""Edgar Lopez"",
                      ""CoachingDate"": ""2025-04-03"",
                      ""CoachingSessionNotes"": ""VCI VC055 Anaheim — backing incidents in the warehouse zone due to unmarked bay entrances. Driver cited poor facility markings as root cause."",
                      ""CoachingSessionActionPlan"": ""Submit facilities improvement request for bay markings. Use backup camera religiously. Recognition issued Jan 2026 for event AASWT91928.""
                    },
                    {
                      ""CoachingSessionId"": 40,
                      ""Coach"": ""Michael Whiting"",
                      ""Driver"": ""Jamison Young"",
                      ""CoachingDate"": ""2025-03-20"",
                      ""CoachingSessionNotes"": ""TCC Windstream Iowa route — speeding on rural roads due to sparse traffic. Driver underestimated wind gusts affecting vehicle handling."",
                      ""CoachingSessionActionPlan"": ""Adhere to posted limits regardless of traffic. Driver recognized for event AASUS99224 in Jan 2026 — full turnaround achieved.""
                    },
                    {
                      ""CoachingSessionId"": 41,
                      ""Coach"": ""Kyle Baker"",
                      ""Driver"": ""Dylan Higdon"",
                      ""CoachingDate"": ""2025-03-07"",
                      ""CoachingSessionNotes"": ""Driver had 4 events in February 2025 — all Cornering triggers on a new route in the Southeast. New driver on the fleet (<6 months)."",
                      ""CoachingSessionActionPlan"": ""90-day mentoring program. Paired with senior driver for all routes.""
                    },
                    {
                      ""CoachingSessionId"": 42,
                      ""Coach"": ""George Black"",
                      ""Driver"": ""Kedrick Kilgore"",
                      ""CoachingDate"": ""2025-02-27"",
                      ""CoachingSessionNotes"": ""IHS Ocala FL — driver had a pattern of distraction-related events near busy intersections on US-27. Recognized for event AATDN33087 in Feb 2026 after sustained improvement."",
                      ""CoachingSessionActionPlan"": ""Install phone holder. No manual GPS operation while driving. Score target: < 2 events per month.""
                    },
                    {
                      ""CoachingSessionId"": 43,
                      ""Coach"": ""Glen Wieck"",
                      ""Driver"": ""Virginia Wieck"",
                      ""CoachingDate"": ""2025-02-13"",
                      ""CoachingSessionNotes"": ""Driver received Driver Recognition from Glen Wieck in Jan 2026 — this coaching session in Feb 2025 was the start of a 12-month improvement plan. Consistent improvement across all metrics."",
                      ""CoachingSessionActionPlan"": ""Monthly score reviews. Driver promoted to safety ambassador in Q4 2025.""
                    },
                    {
                      ""CoachingSessionId"": 44,
                      ""Coach"": ""Melissa Noe"",
                      ""Driver"": ""Anwar Nasir"",
                      ""CoachingDate"": ""2025-01-30"",
                      ""CoachingSessionNotes"": ""UTQ 171 GACE — driver had 3 events in December 2024. Driver is bilingual (Arabic/English) and appreciated coaching materials provided in both languages."",
                      ""CoachingSessionActionPlan"": ""Provide bilingual safety resources. Monthly progress check. Recognized for event AASUZ46975 in Jan 2026 — full improvement confirmed.""
                    },
                    {
                      ""CoachingSessionId"": 45,
                      ""Coach"": ""Monica Scott"",
                      ""Driver"": ""Joshua Kowker"",
                      ""CoachingDate"": ""2025-01-16"",
                      ""CoachingSessionNotes"": ""UTQ 113 NJFR Cream Ridge — hard braking events correlated with late-afternoon fatigue on long routes. Sleep hygiene and shift scheduling reviewed."",
                      ""CoachingSessionActionPlan"": ""Schedule 15-minute break after 3 PM on routes > 4 hours. Recognized for event AASSQ59163 in Jan 2026.""
                    },
                    {
                      ""CoachingSessionId"": 46,
                      ""Coach"": ""John Miller"",
                      ""Driver"": ""Chris Pierre Louis"",
                      ""CoachingDate"": ""2024-12-12"",
                      ""CoachingSessionNotes"": ""UTQ 124 FLSO South Florida — accelerating events on I-95 corridor. Driver cited highway merging pressure as root cause."",
                      ""CoachingSessionActionPlan"": ""Use acceleration assist lane fully before merging. Recognized for event AATDZ30206 in Feb 2026 after sustained improvement.""
                    },
                    {
                      ""CoachingSessionId"": 47,
                      ""Coach"": ""Caleb Benson"",
                      ""Driver"": ""Aaron Beckman"",
                      ""CoachingDate"": ""2024-11-21"",
                      ""CoachingSessionNotes"": ""UTQ 170 GANO Georgia North — speeding on rural highway segments in November 2024. Driver coached on cruise control use and speed limit awareness."",
                      ""CoachingSessionActionPlan"": ""Set cruise control at posted limit on all roads > 45 mph. Recognized for event AATDR50107 in Feb 2026.""
                    },
                    {
                      ""CoachingSessionId"": 48,
                      ""Coach"": ""Timothy Williams"",
                      ""Driver"": ""Cherry DEriko"",
                      ""CoachingDate"": ""2024-10-30"",
                      ""CoachingSessionNotes"": ""PTI MTROWAPLNT — pattern of minor infractions resolved through a comprehensive 12-month coaching program. Driver achieved Driver Recognition from Timothy Williams on 3/24/2026."",
                      ""CoachingSessionActionPlan"": ""Quarterly reviews. Full improvement milestone met March 2026.""
                    },
                    {
                      ""CoachingSessionId"": 49,
                      ""Coach"": ""Michael Bovia"",
                      ""Driver"": ""Dan Haraczka"",
                      ""CoachingDate"": ""2024-10-10"",
                      ""CoachingSessionNotes"": ""Group 29 PUC Parkside Utility — driver had backing incidents near utility job sites in fall 2024. Tight site access and unmarked hazards were contributing factors."",
                      ""CoachingSessionActionPlan"": ""Always designate a ground guide at utility sites. Recognized for event AATDY54516 in Feb 2026.""
                    },
                    {
                      ""CoachingSessionId"": 50,
                      ""Coach"": ""Jeff Griwatsch"",
                      ""Driver"": ""Dylan Albritton"",
                      ""CoachingDate"": ""2024-09-18"",
                      ""CoachingSessionNotes"": ""PUC DuBois PA — driver was new to the northeastern winter routes. Coaching focused on winter driving techniques, low-traction surface handling, and emergency procedures."",
                      ""CoachingSessionActionPlan"": ""Complete winter driving certification before November. Recognized for event AATHT54653 by Melissa Noe on 3/25/2026 — 18-month improvement journey complete.""
                    }
                  ]
                }
                ";
    }
}
