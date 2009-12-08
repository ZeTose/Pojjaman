Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Internal.Parser
Namespace Longkong.Pojjaman.Services
    Public Interface IParseInformation
        ' Properties
        ReadOnly Property BestCompilationUnit() As ICompilationUnitBase
        ReadOnly Property DirtyCompilationUnit() As ICompilationUnitBase
        ReadOnly Property MostRecentCompilationUnit() As ICompilationUnitBase
        ReadOnly Property ValidCompilationUnit() As ICompilationUnitBase
    End Interface
End Namespace



