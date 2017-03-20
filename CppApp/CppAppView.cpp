
// CppAppView.cpp : implementation of the CCppAppView class
//

#include "stdafx.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "CppApp.h"
#endif

#include "CppAppDoc.h"
#include "CppAppView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CCppAppView

IMPLEMENT_DYNCREATE(CCppAppView, CView)

BEGIN_MESSAGE_MAP(CCppAppView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CCppAppView::OnFilePrintPreview)
	ON_WM_CONTEXTMENU()
	ON_WM_RBUTTONUP()
END_MESSAGE_MAP()

// CCppAppView construction/destruction

CCppAppView::CCppAppView()
{
	// TODO: add construction code here

}

CCppAppView::~CCppAppView()
{
}

BOOL CCppAppView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CCppAppView drawing

void CCppAppView::OnDraw(CDC* /*pDC*/)
{
	CCppAppDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
}


// CCppAppView printing


void CCppAppView::OnFilePrintPreview()
{
#ifndef SHARED_HANDLERS
	AFXPrintPreview(this);
#endif
}

BOOL CCppAppView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CCppAppView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CCppAppView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CCppAppView::OnRButtonUp(UINT /* nFlags */, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CCppAppView::OnContextMenu(CWnd* /* pWnd */, CPoint point)
{
#ifndef SHARED_HANDLERS
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
#endif
}


// CCppAppView diagnostics

#ifdef _DEBUG
void CCppAppView::AssertValid() const
{
	CView::AssertValid();
}

void CCppAppView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CCppAppDoc* CCppAppView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CCppAppDoc)));
	return (CCppAppDoc*)m_pDocument;
}
#endif //_DEBUG


// CCppAppView message handlers
