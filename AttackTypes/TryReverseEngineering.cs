// 1. Split up the eight hash values and store them.

/* 2. Subtract Working Variables from Encrypted Hashes
* EH0 -= a;
* EH1 -= b;
* EH2 -= c;
* EH3 -= d;
* EH4 -= e;
* EH5 -= f;
* EH6 -= g;
* EH7 -= h;
*
* Find a: Since a = Temp1 + Temp2 then ->
* 
* Find Temp1: 
* temp1 = h + sum1 + choice + K[63] + MessageSchedule[63];
* The last Temp1 is dependent on the 63rd generation of h, the 64th generation of sum1 (which is dependent on the 63rd generation of e), 
* the 64th generation of choice (which is dependent on the 63rd generation of e, f, and g), the 64th K constant, and the the 64th line in 
* the Message Schedule. The constants used for SHA256 are known, therefore K[63] = c67178f2.
*
* Find 63rd generation of h: 
* h = the 62nd generation of g which = the 62nd generation of f which = the 62nd of e = the 62nd d + the 62nd temp1.
* 
* Find 62nd d:
* d = the 62nd c which = the 62nd b which = the 62nd 'a' which = the 61st temp1 + the 61st temp2
*
* Find 62nd temp1:
* AND THE LIST GOES ON.....
* 
* Even if one recursively travels back to the 1st generation of h, one would then realize they would need to do the same for all the other
* factors. One factor that cannot be traced is the MessageSchedule line, as it is completely dependent on the users's original input/password.  
* This means each MessageSchedule line is dependent on the previous.
* 
* Therefore SHA 256 cannot be reverse engineered.
* */
