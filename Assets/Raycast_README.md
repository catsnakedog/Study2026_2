# Raycast 예제

`Assets/Scenes/01_Raycast.unity` 또는 `Assets/Scenes/02_RaycastEffects.unity`를 열고 Play를 누르세요.

- WASD / 방향키: 현재 캐릭터가 바라보는 방향을 기준으로 앞뒤, 좌우 이동.
- Space: 누를 때 한 발 발사.
- 녹색 영역에 들어가면 1인칭, 나오면 3인칭.
- 레이는 `Debug.DrawRay`로 1초 동안 표시합니다. **Scene 뷰에서 Gizmos를 켜세요. Game 화면에는 선이 표시되지 않습니다.**

## 코드 위치

- `Assets/Scripts/Player`: 기존 PlayerController와 RaycastPlayerController. 둘 다 현재 회전 기준으로 Transform 이동.
- `Assets/Scripts/Combat`: Bullet, Enemy, RaycastShooter, RaycastEffectsShooter.
- `Assets/Scripts/Camera`: CameraViewTrigger.

## 발사 코드

두 발사 스크립트 모두 `Update` 안에서 Space 입력 → Raycast → HP 감소 순서입니다.

`RaycastShooter`는 적중한 오브젝트에서 Enemy를 가져와 바로 HP를 줄입니다.

```csharp
hit.collider.GetComponent<Enemy>().hp -= damage;
```

Enemy가 없는 벽을 맞히면 의도적으로 NullReferenceException이 납니다.

`RaycastEffectsShooter`는 Enemy 태그를 확인하고 HP를 줄인 뒤 피격 파티클을 만듭니다. 발사 후 기본 0.5초 동안 다음 발사를 막습니다.
Enemy 태그와 Enemy 컴포넌트는 같은 오브젝트에 붙입니다. Enemy 스크립트에는 public hp 변수만 있습니다.

## Trigger와 카메라

CameraViewTrigger는 캐릭터의 public `isFirstPerson`만 바꿉니다.
RaycastPlayerController는 bool을 읽어서 두 Camera 중 하나를 켭니다.
제공된 Trigger는 Ignore Raycast 레이어여서 단순한 Physics.Raycast 호출에도 감지되지 않습니다.
Player의 Kinematic Rigidbody는 Trigger 감지용이고, 이동은 Transform으로 처리합니다.

Enemy 선택 → Inspector에서 HP 변화를 확인할 수 있습니다. 적은 주황색, Enemy가 없는 벽은 회색입니다.
프리팹은 `Assets/Prefabs/Enemy.prefab`, `Assets/Prefabs/HitParticle.prefab`입니다.
