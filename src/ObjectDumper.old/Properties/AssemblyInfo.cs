using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("ObjectDumper")]
[assembly: AssemblyDescription("Core assembly of ObjectDumper - dump objects to strings/files")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ObjectDumper")]
[assembly: AssemblyCopyright("Copyright (C) Lasse V. Karlsen 2010-2011, All rights reserved.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("3e0ef58b-022d-4338-b08e-2c068e872f28")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: CLSCompliant(true)]
#if USE_RELEASE_KEY

[assembly: InternalsVisibleTo("ObjectDumper.Tests, PublicKey=00240000048000009400000006020000002400005253413100040000010001006518e40197a668d30af8fa42f0227fc6d214b45eadfb8b890b39ee370394c25b80cbe2fe19a5415d33dfec6b84909df1c8685966461db6c644aa5da5f2b3c65cd837aed1513bc7ce8a9c9d7d4914ac7dd98b4318c1c112a7a2b9e8cef4540ada875b96a5a406f51175473200ba6d77435053a055c40f8301857d748910cfc2ad")]
#else

[assembly: InternalsVisibleTo("ObjectDumper.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b3873160e2fe02227fcc8df15c8beb7bb90a43f375f587ed283f770172cb6215fe4ab11c07508c97cda3220b36e2f59a246b9ab659a49dfd360bbbac1b7bf4e84f1d8c356f6504c3659d8c8742d7cb591254674898fdff5121bd8fd79953ad43bed463fe054b62d27a83ae561380562cd624d775353697c0e28194bd0896df97")]
#endif