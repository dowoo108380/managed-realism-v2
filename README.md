# Managed Realism v2

## 1. 프로젝트 한 줄 설명
2D 탑다운 2대2 자동 전투 AI 캡스톤 프로젝트. Managed Realism v2 기준.

## 2. 이번 학기 필수 범위
- 연속 2축 이동
- turn-rate cap
- fast projectile
- windup / recovery
- train/eval/demo 분리
- baseline 1종
- 프리셋 비교 실험

## 3. 제외 범위
- 완전 자유 조준
- 느린 탄속 선행조준
- 리로드/다중 무기
- 3분 기본 학습

## 4. 모드 프로필
- train: 60s
- eval: 90s
- demo: 120s

## 5. 저장 구조
- artifacts/
- configs/
- runs/
- models/
- batches/
- reports/

## 6. 핵심 추적 체계
config_id -> run_id -> model_id -> batch_id -> battle_id

## 7. 현재 진행 상태
- 완료: BL-001, BL-002, BL-003
- 다음 작업: BL-101 고정 전장 스켈레톤
- 이어서 할 작업: BL-102 BattleClock, BL-004 ManifestWriter

## 8. 개발 환경
- Unity Editor: 6000.3.13f1
- OS: Windows
- 기본 셸: PowerShell 7
