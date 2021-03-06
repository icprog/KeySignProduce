// MFCLibrary1.h: MFCLibrary1 DLL 的主标头文件
//

#pragma once

#ifndef __AFXWIN_H__
	#error "在包含此文件之前包含“stdafx.h”以生成 PCH 文件"
#endif

#include "resource.h"		// 主符号


// CMFCLibrary1App
// 有关此类实现的信息，请参阅 MFCLibrary1.cpp
//

class CMFCLibrary1App : public CWinApp
{
public:
	CMFCLibrary1App();

// 重写
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};


extern "C" _declspec(dllexport) int test(int a, int b);


extern "C" _declspec(dllexport) int Genrootkey(char* str);//产生根密钥对
extern "C" _declspec(dllexport) int Genrootp10(char* str, char* sub_name);//产生根证书P10
extern "C" _declspec(dllexport) int Genrootcer(char* str, char* serial, char* not_befor, char* not_after, char* sub_name, int usep10);//产生根证书
extern "C" _declspec(dllexport) int Genuserkey();//-产生用户密钥对-usegen--1：产生用户公钥对 or 0：导出用户公钥
extern "C" _declspec(dllexport) int Genuserp10(char* str, char* sub_name);//产生用户P10
extern "C" _declspec(dllexport) int Genusercer(char* str, char* serial, char* not_befor, char* not_after, char* subject_name, int usep10);//产生用户证书

extern "C" _declspec(dllexport) int Importcert(char* ibuf);//导入用户证书