# Lab 1: Coding DES, AES using cryptopp library
A. Required:

+) Mode of operations:
  - Select mode from screen (using switch case)
  - Support modes:  ECB, CBC, OFB, CFB, CTR, XTS, CCM, GCM.
+) Funtions: Key generation, encryption, decryption function:
   Select from screen (using command-line or GUI)
+) Inputs:
  - Secret key,  Initialization Vector IV, and nonce,..
  Select from screen (using command-line or GUI)
  Case 1: Secret key and IV are randomly chosen for each run time
  Case 2: Input Secret Key and IV from file (using file name/)
 - Plaintext
    Case 1: Input from screen;
    Case 2: From files (using file name);
    - Support Vietnamse (using setmode, UTF-8)
 - Ciphertext
    Case 1: Input from screen;
    Case 2: From files (using file name);
    - Support Vietnamese (using setmode, UTF-8)
+) Output (hex/base64 encode, binary):
   - display in screen;
   - write to file;

Report Lab 1
Write your report in word file including:
  1. Report your hardware resources;
  2. Report computation performance on Windows and Linux (in tabe with capture image on running your program)

    - Generate a set of different input sizes (at least 6 inputs in size KBs up to MBs)
    - Execute your code and check the computation time on average 10 000 running times;
    - Summarize the results in a tables including: size of input, OS (Windows, Linux), encryption time and decryption time.
    - Do a comparison and your comments on both input size and OS;
    
